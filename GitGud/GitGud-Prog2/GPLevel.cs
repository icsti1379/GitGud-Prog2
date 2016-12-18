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
    class GPLevel : State
    {
        Player player;
        List<Enemy> enemyList;
        List<Projectile> projList;
        Vector2f playerPos, projectilePos;
        View view;
        Clock clock;
        int enemyCounter;
        bool hasFired;


        public GPLevel(int playerLife, int playerRunSpeed, bool playerDoubleScore)
        {
            player = new Player();
            player.SetLife(playerLife);
            player.SetRunSpeed(playerRunSpeed);
            player.SetDoubleScore(playerDoubleScore);
            view = new View(new Vector2f(0, 0), new Vector2f(1200, 700));
        }

        public override GameStates Update()
        {
            return GameStates.GPLevelState;
            throw new NotImplementedException();
        }

        public override void Draw(RenderWindow renderWindow)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
