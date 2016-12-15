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
    /// Ummgehen mit der Kollision von einer Entity mit einem einzelnen Objekt
    /// </summary>
    class EntityCollisionHandling : Collisions
    {
        /// <summary>
        /// erstellen der verschiedenen Kollisionspunkte der Entity
        /// </summary>
        Vector2f colBoxTop;
        Vector2f colBoxRight;
        Vector2f colBoxBottom;
        Vector2f colBoxLeft;
        int offset;

        /// <summary>
        /// Überprüft ob eine Entity mit etwas kollidiert
        /// </summary>
        /// <param name="colRect">Collision Rectangle</param>
        /// <param name="pos">Position der Entity</param>
        /// <param name="offset">breite/höhe des sprites was zumm darstellen der entity genutzt wird</param>
        /// <returns>gibt zurück ob eine Kollision statfindet</returns>
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
