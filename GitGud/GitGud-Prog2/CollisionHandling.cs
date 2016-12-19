using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace GitGudP2
{
    /// <summary>
    /// Überprüft ob eine Entity mit dem Terrain collidiert und gibt die neue Position nach der Collision zurück
    /// </summary>
    class CollisionHandling
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

            //TODO: playerpos anpassen: übergabewert ist tilemaps, brauche aber normale pos
            // -> für x : (1280/2)+xpos. y: (800/2)+ypos

            foreach (IntRect rect in rectList)
            {
                if (GitGudDll.Collision.Check(rect, colBoxTop))
                {
                    newPos.Y = colBoxTop.Y + ((rect.Top + rect.Height) - colBoxTop.Y);
                }
                if (GitGudDll.Collision.Check(rect, colBoxBottom))
                {
                    newPos.Y = colBoxBottom.Y - (colBoxBottom.Y - rect.Top);
                }
                if (GitGudDll.Collision.Check(rect, colBoxLeft))
                {
                    newPos.X = colBoxTop.X + (rect.Left - colBoxLeft.X);
                }
                if (GitGudDll.Collision.Check(rect, colBoxRight))
                {
                    newPos.X = colBoxRight.X - (colBoxRight.X - (rect.Left + rect.Width));
                }
                else
                    pos = newPos;
            }
            return newPos;
        }

        /// <summary>
        /// Überprüft ob eine Entity mit etwas kollidiert. Dazu wird eine Hitbox mitilfe von Punkten erstellt
        /// diese befinden sich oben/rechts/unten/links des animierten charakters
        /// </summary>
        /// <param name="colRect">Collision Rectangle</param>
        /// <param name="pos">Position der Entity</param>
        /// <param name="offset">breite/höhe des sprites was zum darstellen der entity genutzt wird</param>
        /// <returns>gibt zurück ob eine Kollision statfindet</returns>
        public bool EntityWithRectangle(IntRect colRect, Vector2f pos, int offset)
        {
            colBoxTop.X = pos.X + offset / 2;
            colBoxTop.Y = pos.Y;

            colBoxRight.X = pos.X + offset;
            colBoxRight.Y = pos.Y + offset / 2;

            colBoxBottom.X = pos.X + offset / 2;
            colBoxBottom.Y = pos.Y + offset;

            colBoxLeft.X = pos.X;
            colBoxLeft.Y = pos.Y + offset / 2;

            if (GitGudDll.Collision.Check(colRect, colBoxTop) || GitGudDll.Collision.Check(colRect, colBoxRight)
                || GitGudDll.Collision.Check(colRect, colBoxBottom) || GitGudDll.Collision.Check(colRect, colBoxLeft))
                return true;
            else
                return false;
        }

        /// <summary>
        /// gleiche wie methode oben drüber bloß mit einer Liste an Rectangles anstatt eines einzelnen
        /// </summary>
        /// <param name="rectList"></param>
        /// <param name="pos"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public bool EntityWithRectList (List<IntRect> rectList, Vector2f pos, int offset)
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
                if (GitGudDll.Collision.Check(rect, colBoxTop) || GitGudDll.Collision.Check(rect, colBoxRight)
                || GitGudDll.Collision.Check(rect, colBoxBottom) || GitGudDll.Collision.Check(rect, colBoxLeft))
                    isColliding = true;
                else
                    isColliding = false;
            }
            return isColliding;
        }
    }
}
