using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GitGudP2
{
    public class StateMachine
    {
        private GameStates currentState, previousState, targetState;
        private SplashScreen splashScreen;
        private MainMenu mainMenu;
        private GamePlay gamePlay;
        private GPLevel gpLevel;
        private PauseMenu pauseMenu;
        private CreditScreen creditScreen;

        public GameStates CurrentState
        {
            get { return currentState; }
        }

        public StateMachine()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize different states.
        /// </summary>
        private void Initialize()
        {
            // Sets the starting state
            currentState = GameStates.SplashScreenState;
            previousState = GameStates.UnspecifiedState;

            // Initializes the different states
            splashScreen = new SplashScreen();
            mainMenu = new MainMenu();
            gamePlay = new GamePlay();
            pauseMenu = new PauseMenu();
            creditScreen = new CreditScreen();
        }

        /// <summary>
        /// Initialize a specific state.
        /// </summary>
        /// <param name="state">
        /// Initialized state.
        /// </param>
        private void InitializeState(State state)
        {
            if (previousState != currentState)
            {
                state.Initialize();
                previousState = currentState;
            }
        }

        private void DisposeState(State state)
        {
            if (targetState != currentState)
            {
                state.Dispose();
                previousState = currentState;
                currentState = targetState;
            }
        }

        /// <summary>
        /// Checks current state and updates it.
        /// </summary>
        public void Update()
        {
            switch (currentState)
            {
                case GameStates.SplashScreenState:
                    InitializeState(splashScreen);
                    targetState = splashScreen.Update();
                    DisposeState(splashScreen);
                    break;

                case GameStates.MainMenuState:
                    InitializeState(mainMenu);
                    targetState = mainMenu.Update();
                    DisposeState(mainMenu);
                    break;

                case GameStates.PauseMenuState:
                    InitializeState(pauseMenu);
                    targetState = pauseMenu.Update();
                    if (pauseMenu.TargetState == GameStates.MainMenuState)
                    {
                        gamePlay = new GamePlay();
                    }
                    DisposeState(pauseMenu);
                    break;

                case GameStates.CreditScreenState:
                    InitializeState(creditScreen);
                    targetState = creditScreen.Update();
                    DisposeState(creditScreen);
                    break;

                case GameStates.GamePlayState:
                    InitializeState(gamePlay);
                    targetState = gamePlay.Update();
                    DisposeState(gamePlay);
                    if (targetState == GameStates.GPLevelState)
                    {
                        gpLevel = new GPLevel(gamePlay.GetPLayerLife(), gamePlay.GetPlayerRunSpeed(), gamePlay.GetPlayerDoubleScore());
                    }
                    break;

                case GameStates.GPLevelState:
                    InitializeState(gpLevel);
                    targetState = gpLevel.Update();
                    DisposeState(gpLevel);
                    break;

                case GameStates.QuitState:
                    break;

            }
        }


        /// <summary>
        /// Draws the current/active state.
        /// </summary>
        /// <param name="renderWindow"></param>
        public void Draw()
        {
            switch (currentState)
            {
                case GameStates.SplashScreenState:
                    splashScreen.Draw();
                    break;

                case GameStates.MainMenuState:
                    mainMenu.Draw();
                    break;

                case GameStates.PauseMenuState:
                    pauseMenu.Draw();
                    break;

                case GameStates.GamePlayState:
                    gamePlay.Draw();
                    break;

                case GameStates.CreditScreenState:
                    creditScreen.Draw();
                    break;

                case GameStates.GPLevelState:
                    gpLevel.Draw();
                    break;

                case GameStates.QuitState:
                    Game.WindowInstance().Clear(Color.Black);
                    break;
            }
        }

        /// <summary>
        /// Delegates input key for current state.
        /// </summary>
        /// <param name="key">
        /// The key which is pressed.
        /// </param>
        /// <param name="isPressed">
        /// Checks if key is pressed.
        /// </param>
        public void HandleInput(Keyboard.Key key, bool isPressed)
        {
            switch (currentState)
            {
                case GameStates.SplashScreenState:
                    splashScreen.HandleInput(key, isPressed);
                    break;

                case GameStates.MainMenuState:
                    mainMenu.HandleInput(key, isPressed);
                    break;

                case GameStates.PauseMenuState:
                    pauseMenu.HandleInput(key, isPressed);
                    break;

                case GameStates.GamePlayState:
                    gamePlay.HandleInput(key, isPressed);
                    break;

                case GameStates.GPLevelState:
                    gpLevel.HandleInput(key, isPressed);
                    break;

                case GameStates.CreditScreenState:
                    creditScreen.HandleInput(key, isPressed);
                    break;
            }
        }
    }
}
