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
        Enemy enemy;
        List<Enemy> enemyList;
        Projectile projectile;
        List<Projectile> projList;
        View view;
        Map map;
        Chicken kip;
        Clock clock;
        QuestNPCInteraction iQuestNPC;
        UpgradeNPCInteraction iUpgradeNPC;
        int enemyCounter;
        Vector2f playerPos, projectilePos;
        private bool pHasFired, questAccepted;

        public int GetPLayerLife()
        {
            return player.GetLife();
        }

        public int GetPlayerRunSpeed()
        {
            return player.GetRunSpeed();
        }

        public bool GetPlayerDoubleScore()
        {
            return player.GetDoubleScore();
        }
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

            iUpgradeNPC = new UpgradeNPCInteraction();
            iQuestNPC = new QuestNPCInteraction();
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
            foreach (Enemy enemy in enemyList)
                enemy.Update(deltaTime);
            foreach (Projectile proj in projList)
                proj.Update(deltaTime);

            view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));

            playerPos = player.getPlayerPos();
            enemy.PlayerPos(playerPos);
            pHasFired = player.HasFired();

            if (enemyCounter < 10)
                enemyList.Add(new Enemy(enemyCounter));

            if (pHasFired)
                projList.Add(new Projectile(playerPos, 1));

            foreach (Enemy enemy in enemyList)
            {
                foreach (Projectile proj in projList)
                {
                    if (Collision.Collision.Check(enemy.CollisionRect(), proj.ProjectilePos()))
                    {
                        enemy.IsAlive(false);
                        proj.HasKilled(true);
                        player.IncreasePlayerScore(true);
                        enemyList.Remove(enemy);
                        projList.Remove(proj);
                    }
                }
            }

            if (iUpgradeNPC.LifeUpgrade())
                player.SetLife(true);
            if (iUpgradeNPC.RunSpeedUpgrade())
                player.SetRunSpeed(2);
            if (iUpgradeNPC.DoubleScoreUpdate())
                player.SetDoubleScore(true);

            if (iQuestNPC.QuestAccepted())
                return GameStates.GPLevelState;
            else
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
            iQuestNPC.Draw(renderWindow);
            iUpgradeNPC.Draw(renderWindow);
            foreach (Enemy enemy in enemyList)
                enemy.Draw(renderWindow);
            foreach (Projectile proj in projList)
                proj.Draw(renderWindow);

            renderWindow.Display();
        }

    }
}
