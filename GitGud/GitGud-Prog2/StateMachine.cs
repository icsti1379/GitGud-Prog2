﻿using System;
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
    //Benny: im input manager member zum speichern der states schreiben sowie getter/setter
    //in der update methode oder beim initieren der states, wo auch der input manager initiiert wird
    //dann inputmanager.setstatet den aktuellen state übergeben
    public class StateMachine
    {
        private GameStates currentState, previousState, targetState;
        private SplashScreen splashScreen;
        private MainMenu mainMenu;
        private GamePlay gamePlay;
        private GPLevel gpLevel;
        private PauseMenu pauseMenu;
        private CreditScreen creditScreen;
        private GameOver gameOver;

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
            gameOver = new GameOver();
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
                    //InitializeState(splashScreen);
                    targetState = splashScreen.Update();
                    //DisposeState(splashScreen);
                    break;

                case GameStates.MainMenuState:
                    //InitializeState(mainMenu);
                    targetState = mainMenu.Update();
                    //DisposeState(mainMenu);
                    break;

                case GameStates.CreditScreenState:
                    //InitializeState(creditScreen);
                    targetState = creditScreen.Update();
                    //DisposeState(creditScreen);
                    break;

                case GameStates.GamePlayState:
                    //InitializeState(gamePlay);
                    targetState = gamePlay.Update();
                    if (targetState == GameStates.GPLevelState)
                    {
                        gpLevel = new GPLevel(gamePlay.GetPLayerLife(), gamePlay.GetPlayerRunSpeed(), gamePlay.GetPlayerDoubleScore(), gamePlay.GetMaxScore());
                    }
                    //DisposeState(gamePlay);
                    break;

                case GameStates.GPLevelState:
                    //InitializeState(gpLevel);
                    targetState = gpLevel.Update();
                    //DisposeState(gpLevel);
                    break;

                case GameStates.GameOverState:
                    //InitializeState(gameOver);
                    targetState = gameOver.Update();
                    //DisposeState(gameOver);
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

                case GameStates.GPLevelState:
                    gpLevel.Draw(renderWindow);
                    break;

                case GameStates.GameOverState:
                    gameOver.Draw(renderWindow);
                    break;
            }
        }
    }
}
