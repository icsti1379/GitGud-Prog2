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
            RenderWindow window = new RenderWindow(new VideoMode(1280, 800), "GitGudP2", Styles.Close, new ContextSettings(24, 8, 2));
            window.SetFramerateLimit(60);
            window.Closed += WindowClosed;

            // Set view zoom
            View view = new View(new Vector2f(0, 0), new Vector2f(1200, 700));

            
            Map map = new Map();
            Player player = new Player();

            Chicken kip = new Chicken();

            // Set waypoints
            kip.Waypoints = new List<Waypoint>();
            kip.Waypoints.Add(new Waypoint(0, 0));
            kip.Waypoints.Add(new Waypoint(50, 0));
            kip.Waypoints.Add(new Waypoint(50, 50));
            kip.Waypoints.Add(new Waypoint(0, 50));

            
            Clock clock = new Clock();


            while(window.IsOpen)
            {
                window.DispatchEvents();

                // Clear window and set background color to grass green
                window.Clear(new Color(43, 130,53));

                // Clear window and set background color to white
                //window.Clear(new Color(255, 255, 255));

                float deltaTime = clock.Restart().AsSeconds();

               
                // Update
                kip.Update(deltaTime);
                player.Update(deltaTime);

                // Set camera on player and center the view
                view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));
                Console.WriteLine(player.Xpos + player.Ypos);
                window.SetView(view);

                // Draw
                map.Draw(window);
                kip.Draw(window);
                player.Draw(window);

                window.Display();
            }
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
