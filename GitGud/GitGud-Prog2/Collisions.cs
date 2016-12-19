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
    /// base Collision Klasse
    /// </summary>
    class Collisions
    {
        protected List<IntRect> colRectList;
        protected IntRect colRect;
        protected int collisionType;
        Vector2f colVec;
        bool isColliding;

        /// <summary>
        /// zum Überprüfen auf Kollisionen wenn man nur eine Position und ein Rectangle hat
        /// </summary>
        /// <param name="rect">Rectangle zumm kollidieren</param>
        /// <param name="pos">Position</param>
        /// <returns></returns>
        public bool CollisionCheck(IntRect rect, Vector2f pos)
        {
            this.colRect = rect;
            this.colVec = pos;
            if (colRect.Contains((int)colVec.X, (int)colVec.Y))
                return true;
            else
                return false;
        }

        /// <summary>
        /// zum Überprüfen auf Kollisionen einer Position mit einer Liste an Rectangles
        /// </summary>
        /// <param name="rectList"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
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
    }
}
