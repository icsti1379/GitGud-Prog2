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
    class EntityCollisionHandling : Collisions
    {
        Vector2f playerPos;
        Vector2f colBoxTop;
        Vector2f colBoxRight;
        Vector2f colBoxBottom;
        Vector2f colBoxLeft;
        int offset;

        public bool Check(IntRect colRect, Vector2f pos, int offset)
        {
            colBoxTop.X = pos.X + offset / 2;
            colBoxTop.Y = pos.Y;

            colBoxRight.X = pos.X + offset;
            colBoxRight.Y = pos.Y + offset / 2;

            colBoxBottom.X = pos.X + offset / 2;
            colBoxBottom.Y = pos.Y + offset;

            colBoxLeft.X = pos.X;
            colBoxLeft.Y = pos.Y + offset / 2;

            if (CollisionCheck(colRect, colBoxTop) || CollisionCheck(colRect, colBoxRight) || CollisionCheck(colRect, colBoxBottom)
                || CollisionCheck(colRect, colBoxLeft))
                return true;
            else
                return false;
        }
    }
}
