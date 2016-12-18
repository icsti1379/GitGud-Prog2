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
        Text text;
        Font font;
        string textContent, textcontent2;

        int enemyCounter;
        bool pHasFired;


        public GPLevel(int playerLife, int playerRunSpeed, bool playerDoubleScore)
        {
            player = new Player();
            font = new Font("Font/arial.ttf");
            player.SetLife(playerLife);
            player.SetRunSpeed(playerRunSpeed);
            player.SetDoubleScore(playerDoubleScore);
            view = new View(new Vector2f(0, 0), new Vector2f(1200, 700));
        }

        public override GameStates Update()
        {
            float deltaTime = clock.Restart().AsSeconds();

            player.Update(deltaTime);

            foreach (Enemy enemy in enemyList)
                enemy.Update(deltaTime);
            foreach (Projectile proj in projList)
                proj.Update(deltaTime);

            view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));

            playerPos = player.getPlayerPos();

            foreach (Enemy enemy in enemyList)
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

            textContent = Convert.ToString(player.GetPlayerScore());
            textcontent2 = "Score: ";
            text = new Text(textContent + textcontent2, font);

            return GameStates.GPLevelState;

            //throw new NotImplementedException();
        }

        public override void Draw(RenderWindow renderWindow)
        {
            renderWindow.SetView(view);
            renderWindow.Clear(new Color(43, 130, 53));
            //map.Draw(renderWindow);
            player.Draw(renderWindow);
            foreach (Enemy enemy in enemyList)
                enemy.Draw(renderWindow);
            foreach (Projectile proj in projList)
                proj.Draw(renderWindow);

            renderWindow.Display();

            //throw new NotImplementedException();
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
