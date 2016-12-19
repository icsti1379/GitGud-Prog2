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
    /// <summary>
    /// Klasse für die Hub Map
    /// </summary>
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
        QuestNPC questNPC;
        UpgradeNPC upgradeNPC;
        QuestNPCInteraction iQuestNPC;
        UpgradeNPCInteraction iUpgradeNPC;
        CollisionHandling collisionHandling;
        int enemyCounter, maxScore;
        Vector2f playerPos, projectilePos, projDirection;
        private bool pHasFired, questAccepted;
        private Music hubMusic;
        private SoundBuffer upgradSoundBuffer;
        private Sound upgradeSound;
        Interface _interface;

        /// <summary>
        /// nachfolgend 3 getter um die attribute vom spieler zwischen den verschiedenen gameplay states bei zu behalten
        /// </summary>
        /// <returns></returns>
        public int GetPLayerLife()
        {
            return player.GetLife();
        }

        public float GetPlayerRunSpeed()
        {
            return player.GetMoveSpeed();
        }

        public bool GetPlayerDoubleScore()
        {
            return player.GetDoubleScore();
        }

        public int GetMaxScore()
        {
            return maxScore;
        }
        public GamePlay()
        {
            map = new Map();
            view = new View(new Vector2f(0, 0), new Vector2f(1200, 700));

            player = new Player();
            //questNPC = new QuestNPC();
            //upgradeNPC = new UpgradeNPC();
            kip = new Chicken();

            kip.Waypoints = new List<Waypoint>();
            kip.Waypoints.Add(new Waypoint(0, 0));
            kip.Waypoints.Add(new Waypoint(50, 0));
            kip.Waypoints.Add(new Waypoint(50, 50));
            kip.Waypoints.Add(new Waypoint(0, 50));


            clock = new Clock();

            iUpgradeNPC = new UpgradeNPCInteraction();
            iQuestNPC = new QuestNPCInteraction();

            hubMusic = new Music("Music/HubSong.wav");
            upgradSoundBuffer = new SoundBuffer("Sounds/upgrade.wav");
            upgradeSound = new Sound(upgradSoundBuffer);

            collisionHandling = new CollisionHandling();

            _interface = new Interface();
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

            //nachfolgend werden alle entitäten auf der map geupdated
            kip.Update(deltaTime);
            player.Update(deltaTime);
            _interface.Update();
            foreach (Enemy enemy in enemyList)
                enemy.Update(deltaTime);
            foreach (Projectile proj in projList)
                proj.Update(deltaTime);

            view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));

            //holen der verschiedenen variablen für die Kollision
            playerPos = player.getPlayerPos();
            enemy.PlayerPos(playerPos);
            pHasFired = player.HasFired();

            //generieren neuer gegner, oder projektile
            if (enemyCounter < 10)
                enemyList.Add(new Enemy(enemyCounter));

            if (pHasFired)
            {
                switch (player.CurrentState)
                {
                    case CharacterState.MovingUp:
                        projDirection = new Vector2f(0, 1);
                        break;
                    case CharacterState.MovingDown:
                        projDirection = new Vector2f(0, -1);
                        break;
                    case CharacterState.MovingLeft:
                        projDirection = new Vector2f(-1, 0);
                        break;
                    case CharacterState.MovingRight:
                        projDirection = new Vector2f(1, 0);
                        break;

                }
                projList.Add(new Projectile(playerPos, projDirection));
            }

            //überprüft ob ein Projektil einen Gegner getroffen hat und was danach passiert
            foreach (Enemy enemy in enemyList)
            {
                foreach (Projectile proj in projList)
                {
                    if (GitGudDll.Collision.Check(enemy.CollisionRect(), proj.ProjectilePos()))
                    {
                        enemy.IsAlive(false);
                        proj.HasKilled(true);
                        player.IncreasePlayerScore(true);
                        enemyList.Remove(enemy);
                        projList.Remove(proj);
                    }
                }
            }

            //player.setPlayerPos(collisionHandling.WithTerrain(map.GetColRect, player.getPlayerPos, 64));

            //foreach (Enemy enemy in enemyList)
            //{
            //    enemy.SetEnemyPos(collisionHandling.WithTerrain(map.GetColRect, enemy.EnemyPos, 64));
            //}

            //falls upgrades gekauft wurden, anwenden dieser auf den Spieler
            if (iUpgradeNPC.LifeUpgrade())
            {
                player.SetLife(true);
                player.SubstractCoins(5);
                upgradeSound.Play();
            }
            if (iUpgradeNPC.RunSpeedUpgrade())
            {
                player.MoveSpeedUpgrade(2);
                player.SubstractCoins(10);
                upgradeSound.Play();
            }
            if (iUpgradeNPC.DoubleScoreUpdate())
            {
                player.SetDoubleScore(true);
                player.SubstractCoins(15);
                upgradeSound.Play();
            }

            _interface.SetPlayerLife(player.GetLife());
            _interface.SetPlayerPoints((int)player.GetCoins());
            _interface.SetPlayerScore(player.GetPlayerScore());
            _interface.SetQuestCount(player.GetQuestScore());

            //State wechsel, falls quest gestartet wurde
            if (iQuestNPC.QuestAccepted())
            {
                player.SetQuestScore(25);
                return GameStates.GPLevelState;
            }
            else
                return GameStates.GamePlayState;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// zeichnet alle sachen die gezeichnet werden müssen
        /// </summary>
        /// <param name="renderWindow"></param>
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
