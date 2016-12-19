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
        Vector2f projectileDirection;
        int travelSpeedX;
        int travelSpeedY;
        ProjectileCollisionHandling CollisionHandling;

        public Projectile (Vector2f originPos, Vector2f direction)
        {
            this.projectilePos = originPos;
            this.projectileDirection = direction;

        }

        public void Update(float deltaTime)
        {
            projectilePos.X += projectileDirection.X * deltaTime;
            projectilePos.Y += projectileDirection.Y * deltaTime;

            /*if (CollisionHandling.ProjectileCollision())
             * TODO herrausfinden wie ich collision mit allen gegner überprüfe
             * nach collision gegner + projectile entfernen, counter erhöhen 
             */
        }

        public Vector2f ProjectilePos()
        {
            return projectilePos;
        }
    }
}
