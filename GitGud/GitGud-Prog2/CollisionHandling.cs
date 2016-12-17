using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using Collision;


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
        Vector2f translatedPos;

        /// <summary>
        /// Überprüft ob eine Entity mit dem Terrain collidiert und gibt die neue Position nach der Collision zurück
        /// </summary>
        /// <param name="rectList">Liste der Tiles die eine Kollision haben</param>
        /// <param name="pos">Position der Entity</param>
        /// <param name="offset">breite/höhe des sprites was zumm darstellen der entity genutzt wird</param>
        /// <returns>gibt die neue Position zurück</returns>
        public Vector2f WithTerrain(List<IntRect> rectList, Vector2f pos, int offset)
        {
            translatedPos.X = (1280 / 2) + pos.X;
            translatedPos.Y = (800 / 2) + pos.Y;

            colBoxTop.X = translatedPos.X + offset / 2;
            colBoxTop.Y = translatedPos.Y;

            colBoxRight.X = translatedPos.X + offset;
            colBoxRight.Y = translatedPos.Y + offset / 2;

            colBoxBottom.X = translatedPos.X + offset / 2;
            colBoxBottom.Y = translatedPos.Y + offset;

            colBoxLeft.X = translatedPos.X;
            colBoxLeft.Y = translatedPos.Y + offset / 2;

            //TODO: playerpos anpassen: übergabewert ist tilemaps, brauche aber normale pos
            // -> für x : (1280/2)+xpos. y: (800/2)+ypos

            foreach (IntRect rect in rectList)
            {
                if (Collision.Collision.Check(rect, colBoxTop))
                {
                    newPos.Y = colBoxTop.Y + ((rect.Top + rect.Height) - colBoxTop.Y);
                }
                if (Collision.Collision.Check(rect, colBoxBottom))
                {
                    newPos.Y = colBoxBottom.Y - (colBoxBottom.Y - rect.Top);
                }
                if (Collision.Collision.Check(rect, colBoxLeft))
                {
                    newPos.X = colBoxTop.X + (rect.Left - colBoxLeft.X);
                }
                if (Collision.Collision.Check(rect, colBoxRight))
                {
                    newPos.X = colBoxRight.X - (colBoxRight.X - (rect.Left + rect.Width));
                }
                else
                    translatedPos = newPos;
            }
            //newPos.X = 
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
            translatedPos.X = (1280 / 2) + pos.X;
            translatedPos.Y = (800 / 2) + pos.Y;

            colBoxTop.X = translatedPos.X + offset / 2;
            colBoxTop.Y = translatedPos.Y;

            colBoxRight.X = translatedPos.X + offset;
            colBoxRight.Y = translatedPos.Y + offset / 2;

            colBoxBottom.X = translatedPos.X + offset / 2;
            colBoxBottom.Y = translatedPos.Y + offset;

            colBoxLeft.X = translatedPos.X;
            colBoxLeft.Y = translatedPos.Y + offset / 2;

            if (Collision.Collision.Check(colRect, colBoxTop) || Collision.Collision.Check(colRect, colBoxRight)
                || Collision.Collision.Check(colRect, colBoxBottom) || Collision.Collision.Check(colRect, colBoxLeft))
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
            translatedPos.X = (1280 / 2) + pos.X;
            translatedPos.Y = (800 / 2) + pos.Y;

            colBoxTop.X = translatedPos.X + offset / 2;
            colBoxTop.Y = translatedPos.Y;

            colBoxRight.X = translatedPos.X + offset;
            colBoxRight.Y = translatedPos.Y + offset / 2;

            colBoxBottom.X = translatedPos.X + offset / 2;
            colBoxBottom.Y = translatedPos.Y + offset;

            colBoxLeft.X = translatedPos.X;
            colBoxLeft.Y = translatedPos.Y + offset / 2;

            foreach (IntRect rect in rectList)
            {
                if (Collision.Collision.Check(rect, colBoxTop) || Collision.Collision.Check(rect, colBoxRight)
                || Collision.Collision.Check(rect, colBoxBottom) || Collision.Collision.Check(rect, colBoxLeft))
                    isColliding = true;
                else
                    isColliding = false;
            }
            return isColliding;
        }
    }
}
