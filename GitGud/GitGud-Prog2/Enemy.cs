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
    class Enemy : AnimatedCharacter
    {
        Vector2f enemyPos;
        IntRect collisionRect;
        bool isAlive;
        Random rand;
        int seed;

        public Enemy(int enemyCounter) : base("Sprites/Enemy", 64)
        {
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
        public override void Update(float deltaTime)
        {
            
            base.Update(deltaTime);
        }

        public void IsAlive(bool alive)
        {
            isAlive = alive;
        }

        public IntRect CollisionRect()
        {
            return collisionRect;
        }

        public Vector2f EnemyPos()
        {
            return enemyPos;
        }
    }
}
