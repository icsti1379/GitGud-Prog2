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
    /// Überprüft ob eine Entity mit dem Terrain collidiert und gibt die neue Position nach der Collision zurück
    /// </summary>
    class TerrainCollisionHandling : Collisions
    {
        /// <summary>
        /// erstellen der verschiedenen Kollisionspunkte der Entity
        /// </summary>
        bool isColliding;
        Vector2f colBoxTop;
        Vector2f colBoxRight;
        Vector2f colBoxBottom;
        Vector2f colBoxLeft;
        Vector2f newPos;

        /// <summary>
        /// Überprüft ob eine Entity mit dem Terrain collidiert und gibt die neue Position nach der Collision zurück
        /// </summary>
        /// <param name="rectList">Liste der Tiles die eine Kollision haben</param>
        /// <param name="pos">Position der Entity</param>
        /// <param name="offset">breite/höhe des sprites was zumm darstellen der entity genutzt wird</param>
        /// <returns>gibt die neue Position zurück</returns>
        public Vector2f WithTerrain(List<IntRect> rectList, Vector2f pos, int offset)
        {
            colBoxTop.X = pos.X + offset / 2;
            colBoxTop.Y = pos.Y;

            colBoxRight.X = pos.X + offset;
            colBoxRight.Y = pos.Y + offset / 2;

            colBoxBottom.X = pos.X + offset / 2;
            colBoxBottom.Y = pos.Y + offset;

            colBoxLeft.X = pos.X;
            colBoxLeft.Y = pos.Y + offset / 2;

            foreach (IntRect rect in rectList)
            {
                if (CollisionCheck(rect, colBoxTop))
                {
                    newPos.Y = colBoxTop.Y + ((rect.Top + rect.Height) - colBoxTop.Y);
                }
                if (CollisionCheck(rect, colBoxBottom))
                {
                    newPos.Y = colBoxBottom.Y - (colBoxBottom.Y - rect.Top);
                }
                if (CollisionCheck(rect, colBoxLeft))
                {
                    newPos.X = colBoxTop.X + (rect.Left - colBoxLeft.X);
                }
                if (CollisionCheck(rect, colBoxRight))
                {
                    newPos.X = colBoxRight.X - (colBoxRight.X - (rect.Left + rect.Width));
                }
                else
                    pos = newPos;
            }
            return newPos;
        }
    }
}
