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
    class ProjectileCollisionHandling : Collisions
    {
        /// <summary>
        /// Überprüft ob ein Projectile mit einem collision Rectangle, z.b. Gegner, kollidiert
        /// </summary>
        /// <param name="colRect"></param>
        /// <param name="projPos"></param>
        /// <returns></returns>
        public bool ProjectileCollision(IntRect colRect, Vector2f projPos)
        {
            if (CollisionCheck(colRect, projPos))
                return true;
            else
                return false;
        }
    }
}
