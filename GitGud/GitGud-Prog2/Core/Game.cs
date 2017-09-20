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
    public class Game
    {
        #region Static        
        
        /// <summary>
        /// A reference to the active Game instance.
        /// </summary>
        public static Game Intance;

        #endregion

        #region Private

        Stopwatch rendertime = new Stopwatch();
        Stopwatch updateTime = new Stopwatch();
        Stopwatch gameTime = new Stopwatch();


        float cameraAngle, cameraZoom;

        float deltaTime = 0;

        float frameTime;
        float lastTime = 0;
        float fpsTime = 0;
        float skipTime;

        internal View View;
        internal RenderWindow Window;

        List<Scene> goToScenes = new List<Scene>();
        Scene GetScene;

        List<Scene> scenesToRender = new List<Scene>();

        int removeSceneCount = 0;

        Process proc = Process.GetCurrentProcess();


    }

    //class Game
    //{
    //    static StateMachine stateMachine;

    //    static RenderWindow window = null;

    //    /// <summary>
    //    /// Create new window, if no window is open.
    //    /// </summary>
    //    /// <returns>
    //    /// Returns window.
    //    /// </returns>
    //    public static RenderWindow WindowInstance()
    //    {
    //        if (window == null)
    //        {
    //            window = new RenderWindow(new VideoMode(1280, 800), "GitGudP2", Styles.Close,
    //                new ContextSettings(24, 8, 2));
    //            return window;
    //        }
    //        return window;
    //    }

    //    public void Start()
    //    {
    //        Game.WindowInstance().SetActive();
    //        Game.WindowInstance().SetFramerateLimit(60);

    //        stateMachine = new StateMachine();
            
    //        // Raise events as a pointer to the method
    //        WindowInstance().KeyPressed += (o, a) => HandleKeyInput(a.Code, true);
    //        WindowInstance().KeyReleased += (o, a) => HandleKeyInput(a.Code, false);

    //        // As long as CurrentState is not QuitState, hold GameLoop active
    //        while (stateMachine.CurrentState != GameStates.QuitState)
    //        {
    //            GameLoop();
    //        }
    //    }

    //    /// <summary>
    //    /// Delegates input key for current state.
    //    /// </summary>
    //    /// <param name="key">
    //    /// The key which is pressed.
    //    /// </param>
    //    /// <param name="isPressed">
    //    /// Checks if key is pressed.
    //    /// </param>
    //    private static void HandleKeyInput(Keyboard.Key key, bool isPressed)
    //    {
    //        stateMachine.HandleInput(key, isPressed);
    //    }

    //    /// <summary>
    //    /// Application game loop
    //    /// </summary>
    //    private static void GameLoop()
    //    {
    //        // Update
    //        stateMachine.Update();
    //        WindowInstance().DispatchEvents();

    //        // Draw
    //        WindowInstance().Clear(new Color(43, 130, 53));
    //        stateMachine.Draw();
    //        WindowInstance().Display();
    //   }
    //}
}
