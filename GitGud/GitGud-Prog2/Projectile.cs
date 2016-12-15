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

        public  Projectile (Vector2f originPos, Vector2f direction)
        {

        }

        public Vector2f ProjectilePos()
        {
            return projectilePos;
        }
    }
}
