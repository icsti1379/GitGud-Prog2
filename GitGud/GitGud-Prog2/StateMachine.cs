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

using GitGudP2.States;

namespace GitGudP2
{
    public class StateMachine
    {
        private GameStates currentState, previousState, targetState;
        private SplashScreen splashScreen;
        private MainMenu mainMenu;
        private GamePlay gamePlay;
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

        private void Initialize()
        {
            //Sets the starting state
            currentState = GameStates.SplashScreenState;
            previousState = GameStates.UnspecifiedState;

            //Initializes the different states
            splashScreen = new SplashScreen();
            mainMenu = new MainMenu();
            gamePlay = new GamePlay();
            pauseMenu = new PauseMenu();
            creditScreen = new CreditScreen();
        }

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

                case GameStates.CreditScreenState:
                    InitializeState(creditScreen);
                    targetState = creditScreen.Update();
                    DisposeState(creditScreen);
                    break;

                case GameStates.GamePlayState:
                    InitializeState(gamePlay);
                    targetState = gamePlay.Update();
                    DisposeState(gamePlay);
                    if (targetState == GameStates.CreditScreenState)
                    {
                        gamePlay = new GamePlay();
                    }
                    break;

                case GameStates.QuitState:
                    break;

            }
        }

        public void Draw(RenderWindow renderWindow)
        {
            switch (currentState)
            {
                case GameStates.SplashScreenState:
                    splashScreen.Draw(renderWindow);
                    break;

                case GameStates.MainMenuState:
                    mainMenu.Draw(renderWindow);
                    break;

                case GameStates.GamePlayState:
                    gamePlay.Draw(renderWindow);
                    break;

                case GameStates.CreditScreenState:
                    creditScreen.Draw(renderWindow);
                    break;
            }
        }
    }
}
