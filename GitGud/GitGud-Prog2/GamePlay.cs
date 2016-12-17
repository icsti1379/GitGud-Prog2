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
    public class GamePlay : State
    {
        Player player;
        View view;
        Map map;
        Chicken kip;
        Clock clock;
        NPCinteraction interaction;

        public GamePlay()
        {
            map = new Map();
            view = new View(new Vector2f(0, 0), new Vector2f(1200, 700));

            player = new Player();

            kip = new Chicken();

            kip.Waypoints = new List<Waypoint>();
            kip.Waypoints.Add(new Waypoint(0, 0));
            kip.Waypoints.Add(new Waypoint(50, 0));
            kip.Waypoints.Add(new Waypoint(50, 50));
            kip.Waypoints.Add(new Waypoint(0, 50));


            clock = new Clock();

            interaction = new NPCinteraction(1);
        }

        public override void Dispose()
        {
            // throw new NotImplementedException();
        }

        public override void Initialize()
        {

            //throw new NotImplementedException();
        }

        public override GameStates Update()
        {
            float deltaTime = clock.Restart().AsSeconds();

            kip.Update(deltaTime);
            player.Update(deltaTime);

            view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));

            return GameStates.GamePlayState;
            //throw new NotImplementedException();
        }

        public override void Draw(RenderWindow renderWindow)
        {

            //throw new NotImplementedException();
            renderWindow.SetView(view);
            renderWindow.Clear(new Color(43, 130, 53));
            map.Draw(renderWindow);
            kip.Draw(renderWindow);
            player.Draw(renderWindow);
            interaction.Draw(renderWindow);

            renderWindow.Display();
        }

    }
}
