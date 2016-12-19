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
        public void Start()
        {
            RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(1280, 800), "GitGudP2", Styles.Close, new ContextSettings(24, 8, 2));
            window.SetFramerateLimit(60);
            window.Closed += WindowClosed;

            StateMachine stateMashine = new StateMachine();
            //Map map = new Map();
            //View view = new View(new Vector2f(0, 0), new Vector2f(800, 600));

            //Player player = new Player();
            
            //Chicken kip = new Chicken();

            //kip.Waypoints = new List<Waypoint>();
            //kip.Waypoints.Add(new Waypoint(0, 0));
            //kip.Waypoints.Add(new Waypoint(50, 0));
            //kip.Waypoints.Add(new Waypoint(50, 50));
            //kip.Waypoints.Add(new Waypoint(0, 50));

            
            //Clock clock = new Clock();


            while(window.IsOpen)
            {
                stateMashine.Update();
                stateMashine.Draw(window);
                //window.DispatchEvents();

                //window.Clear(new Color(43, 130,53));

                //float deltaTime = clock.Restart().AsSeconds();

               

                //kip.Update(deltaTime);
                //player.Update(deltaTime);

                //view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));
                //window.SetView(view);


                //map.Draw(window);
                //kip.Draw(window);
                //player.Draw(window);

                //window.Display();
            }
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
