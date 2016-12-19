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
    /// Basisklasse für Projektile
    /// </summary>
    class Projectile
    {
        Vector2f projectilePos;
        Vector2f newProjPos;
        Vector2f projectileDirection;
        int travelSpeed;
        CollisionHandling CollisionHandling;
        Sprite projectileSprite;
        CircleShape projDisplay;
        bool hasKilled;

        public Projectile (Vector2f originPos, Vector2f direction)
        {
            travelSpeed = 10;
            //Umrechnen von der tilemap position des Spielers auf das normale Koordinatensystem
            //dient als startposition des geschosses
            projectilePos = originPos;

            projectileDirection = direction * travelSpeed;

            //generiert den kreis zum späteren zeichen
            projDisplay = new CircleShape(2);
            projDisplay.FillColor = Color.Black;

            //TODO: mit originPos und direction die richtung des projektils herraus bekommen

            //if (projectileDirection.X < projectilePos.X && projectileDirection.Y < projectilePos.Y)
            //{

            //}

            //if (projectileDirection.X < projectilePos.X && projectileDirection.Y > projectilePos.Y)
            //{

            //}

            //if (projectileDirection.X > projectilePos.X && projectileDirection.Y < projectilePos.Y)
            //{

            //}

            //if (projectileDirection.X > projectilePos.X && projectileDirection.Y > projectilePos.Y)
            //{

            //}
        }

        public void Update(float deltaTime)
        {
            newProjPos = projectilePos + projectileDirection;
            projectilePos = newProjPos;
            projDisplay.Position = projectilePos;

            /*if (CollisionHandling.ProjectileCollision())
             * TODO herrausfinden wie ich collision mit allen gegner überprüfe
             * nach collision gegner + projectile entfernen, counter erhöhen 
             * foreach (Enemy enemy in playerList)
             * if (collision.collision.check(enemy.rect, projectilepos))
             *      enemy.dispose();
             *      Player.setScore(+1);
             *      projectile.dispose();
             *      hasKilled = true;
             * else
             *      newProjPos = projectilePos * projectileDirection;
             *      projectilePos = newProjPos;
             *      hasKilled = false;
             */
        }

        public void Draw(RenderWindow renderWindow)
        {
            renderWindow.Draw(projDisplay);
            //TODO: projectile anhand der neuen Position zeichnen
        }

        //getter und setter zur Kollisionsberechnung und dessen Folge
        public Vector2f ProjectilePos()
        {
            return projectilePos;
        }

        public bool HasKilled()
        {
            return hasKilled;
        }

        public void HasKilled(bool killed)
        {
            hasKilled = killed;
        }
    }
}
