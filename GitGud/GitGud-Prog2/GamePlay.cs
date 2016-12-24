
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Gameplay state which is also the hub level.
    /// </summary>
    public class GamePlay : State
    {
        Player player;
        //Enemy enemy;
        List<Enemy> enemyList = new List<Enemy>();
        //Enemy addEnemy;
        Projectile projectile;
        List<Projectile> projList = new List<Projectile>();
        View view;
        Map map;
        Chicken kip;
        Clock clock;
        QuestNPCInteraction iQuestNPC;
        UpgradeNPCInteraction iUpgradeNPC;
        int enemyCounter = 1;
        Vector2f playerPos, projectilePos;
        private bool pHasFired, questAccepted;
        private Music hubMusic;
        private SoundBuffer upgradSoundBuffer;
        private Sound upgradeSound;

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
        public GamePlay()
        {
            map = new Map();
            view = new View(new Vector2f(0, 0), new Vector2f(1200, 700));

            player = new Player();
            //enemy = new Enemy(0);
            kip = new Chicken();

            kip.Waypoints = new List<Waypoint>();
            kip.Waypoints.Add(new Waypoint(0, 0));
            kip.Waypoints.Add(new Waypoint(50, 0));
            kip.Waypoints.Add(new Waypoint(50, 50));
            kip.Waypoints.Add(new Waypoint(0, 50));

            

            clock = new Clock();

            iUpgradeNPC = new UpgradeNPCInteraction();
            iQuestNPC = new QuestNPCInteraction();

            hubMusic = new Music("Music/HubSong.ogg");
            upgradSoundBuffer = new SoundBuffer("Sounds/upgrade.wav");
            upgradeSound = new Sound(upgradSoundBuffer);
        }

        public override void Dispose()
        {
            // throw new NotImplementedException();
        }

        public override void Initialize()
        {
            // Initialize music and loop it 
            hubMusic.Play();
            hubMusic.Loop = true;
        }


        //TODO NOCHMAL PRÜFEN OB ÜBERHAUPT DIE RICHTIGEN INPUTS ABGEFRAGT WERDEN
        public override void HandleInput(Keyboard.Key key, bool isPressed)
        {
            player.HandleInput(key, isPressed);
        }

        public override GameStates Update()
        {
            float deltaTime = clock.Restart().AsSeconds();

            //while (enemyCounter < 20)
            //{
            //    addEnemy = new Enemy(1);
            //    enemyCounter++;

            //    Console.WriteLine("enemy" + addEnemy);
            //}



            //generieren neuer gegner, oder projektile
            if (enemyCounter < 10)
            {
                Console.WriteLine("enemy counter " + enemyCounter);
                enemyCounter++;

                enemyList.Add(new Enemy(enemyCounter));

            }

            if (pHasFired)
                projList.Add(new Projectile(playerPos, 1));

            //nachfolgend werden alle entitäten auf der map geupdated
            kip.Update(deltaTime);
            player.Update(deltaTime);
            foreach (Enemy fEnemy in enemyList)
            {
                fEnemy.Update(deltaTime);
                fEnemy.PlayerPos(playerPos);
            }
                
            foreach (Projectile proj in projList)
                proj.Update(deltaTime);

            view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));

            //holen der verschiedenen variablen für die Kollision
            playerPos = player.getPlayerPos();
            pHasFired = player.HasFired();


            //überprüft ob ein Projektil einen Gegner getroffen hat und was danach passiert
            foreach (Enemy fEnemy in enemyList)
            {
                foreach (Projectile proj in projList)
                {
                    if (GitGudDll.Collision.Check(fEnemy.CollisionRect(), proj.ProjectilePos()))
                    {
                        fEnemy.IsAlive(false);
                        proj.HasKilled(true);
                        player.IncreasePlayerScore(true);
                        enemyList.Remove(fEnemy);
                        projList.Remove(proj);
                    }
                }
            }

            //falls upgrades gekauft wurden, anwenden dieser auf den Spieler
            if (iUpgradeNPC.LifeUpgrade())
            {
                player.SetLife(true);
                upgradeSound.Play();
            }
            if (iUpgradeNPC.RunSpeedUpgrade())
            {
                player.MoveSpeedUpgrade(2);
                upgradeSound.Play();
            }
            if (iUpgradeNPC.DoubleScoreUpdate())
            {
                player.SetDoubleScore(true);
                upgradeSound.Play();
            }

            //State wechsel, falls quest gestartet wurde
            if (iQuestNPC.QuestAccepted())
                return GameStates.GPLevelState;
            else
                return GameStates.GamePlayState;
        }

        /// <summary>
        /// zeichnet alle sachen die gezeichnet werden müssen
        /// </summary>
        public override void Draw()
        {
            Game.WindowInstance().SetView(view);
            Game.WindowInstance().Clear(new Color(43, 130, 53));
            map.Draw();
            kip.Draw();
            player.Draw();
            //iQuestNPC.Draw();
            //iUpgradeNPC.Draw();
            foreach (Enemy fEnemy in enemyList)
                fEnemy.Draw();
            foreach (Projectile proj in projList)
                proj.Draw();
            //addEnemy.Draw();
            Game.WindowInstance().Display();
        }
    }
}
