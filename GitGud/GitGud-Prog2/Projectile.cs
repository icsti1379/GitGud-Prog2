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
    class Projectile
    {
        Vector2f projectilePos;
        Vector2f newProjPos;
        float projectileDirection;
        int travelSpeedX;
        int travelSpeedY;
        CollisionHandling CollisionHandling;

        public Projectile (Vector2f originPos, float direction)
        {
            this.projectilePos = originPos;
            this.projectileDirection = direction;

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
            newProjPos = projectilePos * projectileDirection;
            projectilePos = newProjPos;

            /*if (CollisionHandling.ProjectileCollision())
             * TODO herrausfinden wie ich collision mit allen gegner überprüfe
             * nach collision gegner + projectile entfernen, counter erhöhen 
             */
        }

        public void Draw()
        {
            //TODO: projectile anhand der neuen Position zeichnen
        }

        public Vector2f ProjectilePos()
        {
            return projectilePos;
        }
    }
}
