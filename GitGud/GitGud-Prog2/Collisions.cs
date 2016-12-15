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
    class Collisions
    {
        protected List<IntRect> colRectList;
        protected IntRect colRect;
        protected int collisionType;
        Vector2f colVec;
        bool isColliding;

        public bool CollisionCheck(IntRect rect, Vector2f pos)
        {
            this.colRect = rect;
            this.colVec = pos;
            if (colRect.Contains((int)colVec.X, (int)colVec.Y))
                return true;
            else
                return false;
        }

        public bool CollisionCheck(List<IntRect> rectList, Vector2f pos)
        {
            this.colRectList = rectList;
            this.colVec = pos;
            foreach (IntRect rect in colRectList)
            {
                if (rect.Contains((int)colVec.X, (int)colVec.Y))
                    isColliding = true;
                else
                    isColliding = false;
            }
            return isColliding;
        }

        public virtual void Update()
        {
        }
    }
}
