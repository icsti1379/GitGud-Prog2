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

        public bool ProjectileCollision(IntRect colRect, Vector2f projPos)
        {
            if (CollisionCheck(colRect, projPos))
                return true;
            else
                return false;
        }
    }
}
