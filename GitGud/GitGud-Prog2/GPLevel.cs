﻿using System;
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
    /// Klasse für die eigentlichen Level
    /// </summary>
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
        private SoundBuffer shootSoundBuffer, deathSoundBuffer;
        private Sound shootSound, deathSound;
        private Music gameMusic;
        string textContent, textcontent2;

        int enemyCounter, maxScore;
        bool pHasFired;

        /// <summary>
        /// Konstruktor, Übergabewerte sind dazu da die attribute des Spielers bei zu behalten
        /// </summary>
        /// <param name="playerLife"></param>
        /// <param name="playerRunSpeed"></param>
        /// <param name="playerDoubleScore"></param>
        public GPLevel(int playerLife, float playerRunSpeed, bool playerDoubleScore, int maxScore)
        {
            this.maxScore = maxScore;
            player = new Player();
            font = new Font("Font/arial.ttf");
            player.SetLife(playerLife);
            player.SetMoveSpeed(playerRunSpeed);
            player.SetDoubleScore(playerDoubleScore);
            view = new View(new Vector2f(0, 0), new Vector2f(1200, 700));
            gameMusic = new Music("Music/GameSong1.wav");
            gameMusic.Play();
            shootSoundBuffer = new SoundBuffer("Sounds/shoot.wav");
            shootSound = new Sound(shootSoundBuffer);
            deathSoundBuffer = new SoundBuffer("Sounds/death.wav");
            deathSound = new Sound(deathSoundBuffer);
        }

        public override GameStates Update()
        {
            float deltaTime = clock.Restart().AsSeconds();

            //update aller entitäten auf der map
            player.Update(deltaTime);

            foreach (Enemy enemy in enemyList)
                enemy.Update(deltaTime);
            foreach (Projectile proj in projList)
                proj.Update(deltaTime);

            view.Center = new Vector2f((player.Xpos + 32), (player.Ypos + 32));

            //getten der playerpos und weitergabe an alle Gegner für die Waypoints
            playerPos = player.getPlayerPos();

            foreach (Enemy enemy in enemyList)
                enemy.PlayerPos(playerPos);

            //schauen ob der spieler gefeuert hat und danach erzeugen des projektils bzw.
            //er gegner wenn weniger als enemycounter aktiv sind
            pHasFired = player.HasFired();

            if (enemyCounter < 10)
                enemyList.Add(new Enemy(enemyCounter));

            if (pHasFired)
            {
                projList.Add(new Projectile(playerPos, 1));
                shootSound.Play();
            }
            //überprüft ob ein projektil einen gegner getroffen hat und handelt
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
                        deathSound.Play();
                    }
                }
            }

            //setzen des aktuellen Punktestandes
            textContent = Convert.ToString(player.GetPlayerScore());
            textcontent2 = "Score: ";
            text = new Text(textContent + textcontent2, font);

            if (player.GetLife() <= 0)
                return GameStates.GameOverState;
            if (player.GetPlayerScore() == maxScore)
                return GameStates.GamePlayState;
            else
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