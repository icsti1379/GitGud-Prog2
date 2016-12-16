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

using GitGudP2;

namespace GitGudP2.States
{
    public class GamePlay : State
    {
        //World world;
        //Player player;
        //QuestNPC questNPC;
        //EnemyNPC enemyNPC;
        Player player;
        View view;
        Map map;
        Chicken kip;
        Clock clock;

        public GamePlay()
        {
            //world = new World();
            //player = new Player();
            //questNPC = new QuestNPC();
            //enemyNPC = new EnemyNPC();
            map = new Map();
            view = new View(new Vector2f(0, 0), new Vector2f(800, 600));

            player = new Player();

            kip = new Chicken();

            kip.Waypoints = new List<Waypoint>();
            kip.Waypoints.Add(new Waypoint(0, 0));
            kip.Waypoints.Add(new Waypoint(50, 0));
            kip.Waypoints.Add(new Waypoint(50, 50));
            kip.Waypoints.Add(new Waypoint(0, 50));


            clock = new Clock();
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

            //player.Update(world.CurrentRoom);
            return GameStates.GamePlayState;
            //throw new NotImplementedException();
        }

        public override void Draw(RenderWindow renderWindow)
        {
            //world.Draw();
            //player.Draw();
            //questNPC.Draw();
            //enemyNPC.Draw();
            //throw new NotImplementedException();
            renderWindow.SetView(view);
            renderWindow.Clear(new Color(43, 130, 53));
            map.Draw(renderWindow);
            kip.Draw(renderWindow);
            player.Draw(renderWindow);

            renderWindow.Display();
        }

    }
}
