using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;

namespace GitGudP2
{
    /// <summary>
    /// Basis Enemy Klasse
    /// </summary>
    class Enemy : AnimatedCharacterWithAI
    {
        Vector2f enemyPos, playerPos, waypointPos;
        IntRect collisionRect;
        bool isAlive;
        Random rand;
        int seed;
        Waypoint waypoint;
        List<Waypoint> waypoints;

        /// <summary>
        /// Konstruktor, erstellt einen gegner mit random spawn am rand der map
        /// und erzeugt ein rechteck um das sprite für die Kollisionsabfrage
        /// </summary>
        /// <param name="enemyCounter">anzahl der momentanen gegner auf der map, wird als seed für die spawn location genommen</param>
        public Enemy(int enemyCounter) : base("Sprites/Enemy/enemy01", 64)
        {
            Anim_Up = new Animation(0, 0, 10);
            Anim_Left = new Animation(64, 0, 10);
            Anim_Down = new Animation(128, 0, 10);
            Anim_Right = new Animation(256, 0, 10);

            waypoints = new List<Waypoint>();
            rand = new Random();
            seed = enemyCounter % 4;

            switch (seed)
            {
                case 1:
                    enemyPos.X = 40 + rand.Next() % 1200;
                    enemyPos.Y = 20 + rand.Next() % 20;
                    break;
                case 2:
                    enemyPos.X = 40 + rand.Next() % 40;
                    enemyPos.Y = 20 + rand.Next() % 760;
                    break;
                case 3:
                    enemyPos.X = 40 + rand.Next() % 1200;
                    enemyPos.Y = 780 - rand.Next() % 20;
                    break;
                case 4:
                    enemyPos.X = 1240 - rand.Next() % 40;
                    enemyPos.Y = 20 + rand.Next() % 760;
                    break;
            }

            collisionRect = new IntRect((int)enemyPos.X, (int)enemyPos.Y, 64, 64);
        }

        /// <summary>
        /// gibt jedes Update die aktuelle Position des spielers als waypoint
        /// ziel ist, dass er sich jedes update die position des spieler als neuen waypoint gibt
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            //if (enemyPos.X < playerPos.X)
            //    waypointPos.X = (playerPos.X - enemyPos.X) / 100;
            //if (playerPos.X < enemyPos.X)
            //    waypointPos.X = (enemyPos.X - playerPos.X) / 100;
            //if (enemyPos.Y < playerPos.Y)
            //    waypointPos.Y = (playerPos.Y - enemyPos.Y) / 100;
            //if (playerPos.Y < enemyPos.Y)
            //    waypointPos.Y = (enemyPos.Y - playerPos.Y) / 100;
            //else
            //    waypointPos = enemyPos;
            waypoints.Clear();
            waypoints.Add(new Waypoint(waypointPos.X, waypointPos.Y));

            base.Update(deltaTime);
        }

        /// <summary>
        /// setter, um nach erfolgreicher Kollision mit Projektilen den gegner auf nicht lebend zu setzen
        /// </summary>
        /// <param name="alive"></param>
        public void IsAlive(bool alive)
        {
            isAlive = alive;
        }

        /// <summary>
        /// getter, um für die Kollisions abfrage das Kollisions rechteck des gegners zu bekommen
        /// </summary>
        /// <returns></returns>
        public IntRect CollisionRect()
        {
            return collisionRect;
        }

        /// <summary>
        /// getter um die gegnerposition zu bekommen
        /// </summary>
        /// <returns></returns>
        public Vector2f EnemyPos()
        {
            return enemyPos;
        }

        /// <summary>
        /// setter um die aktuelle positions des spielers zu bekommen
        /// für waypoints benötigt
        /// </summary>
        /// <param name="pos"></param>
        public void PlayerPos(Vector2f pos)
        {
            playerPos = pos;
        }
    }
}
