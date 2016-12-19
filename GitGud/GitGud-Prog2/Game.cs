// TODO CHECK USELESS CODE AND REMOVE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GitGudP2
{
    class Game
    {
        static StateMachine stateMachine;

        static RenderWindow window = null;

        /// <summary>
        /// Create new window, if no window is open.
        /// </summary>
        /// <returns>
        /// Returns window.
        /// </returns>
        public static RenderWindow WindowInstance()
        {
            if (window == null)
            {
                window = new RenderWindow(new VideoMode(1280, 800), "GitGudP2", Styles.Close,
                    new ContextSettings(24, 8, 2));
                return window;
            }
            return window;
        }

        public void Start()
        {
            Game.WindowInstance().SetActive();
            Game.WindowInstance().SetFramerateLimit(60);

            stateMachine = new StateMachine();
            
            // Raise events as a pointer to the method
            WindowInstance().KeyPressed += (o, a) => HandleKeyInput(a.Code, true);
            WindowInstance().KeyReleased += (o, a) => HandleKeyInput(a.Code, false);

            // As long as CurrentState is not QuitStae, hold GameLoop active
            while (stateMachine.CurrentState != GameStates.QuitState)
            {
                GameLoop();
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
        private static void HandleKeyInput(Keyboard.Key key, bool isPressed)
        {
            stateMachine.HandleInput(key, isPressed);
        }

        /// <summary>
        /// Application game loop
        /// </summary>
        private static void GameLoop()
        {
            // Update
            stateMachine.Update();
            WindowInstance().DispatchEvents();

            // Draw
            WindowInstance().Clear(new Color(43, 130, 53));
            stateMachine.Draw();
            WindowInstance().Display();
       }
    }
}
