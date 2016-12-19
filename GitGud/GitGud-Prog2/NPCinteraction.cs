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
    /// Basisklasse für NPC Interaktion
    /// </summary>
    class NPCinteraction
    {

        RectangleShape rectangle;
        protected Text text1, text2, text3, text4;
        protected string textContent;
        protected Font font;
        protected bool interactionPossible;
        protected Vector2f text1Pos, text2Pos, text3Pos, text4Pos;

        /// <summary>
        /// getter der zurück gibt ob eine Interaktion möglich ist,
        /// also sich der spieler in der collision box befindet
        /// </summary>
        /// <returns></returns>
        public bool getiPossible()
        {
            return interactionPossible;
        }

        /// <summary>
        /// setter für die Interaktion
        /// </summary>
        /// <param name="iPossible"></param>
        public void setiPossible(bool iPossible)
        {
            interactionPossible = iPossible;
        }

        /// <summary>
        /// Konstruktor für die Basis Interaktionsklasse
        /// erstellt ein rechteck zum zeichnen, sowie die position für die texte
        /// </summary>
        public NPCinteraction()
        {
            font = new Font("Font/arial.ttf");
            text1Pos = new Vector2f(420, 220);
            text2Pos = new Vector2f(420, 240);
            text3Pos = new Vector2f(420, 260);
            text4Pos = new Vector2f(420, 280);

            //switch (identifier)
            //{
            //    case 1:
            //        textContent = "this is a quest Text";
            //        break;
            //    case 2:
            //        textContent = "this is an upgrade Text";
            //        break;
            //}

            //text1 = new Text(textContent, font);
            //text1.Position = new Vector2f(52, 52);

            rectangle = new RectangleShape(new Vector2f(400, 200));
            rectangle.Position = new Vector2f(50, 50);
            rectangle.FillColor = Color.Black;
            rectangle.OutlineColor = Color.Red;
            rectangle.OutlineThickness = 2;

            interactionPossible = true;
            //TODO: oberes rausnehmen wenn collision fertig integriert ist
        }
        public virtual void Update()
        {
            //switch (identifier)
            //{
            //    case 1:
            //        input->quest annehmen / ablehnen
            //        y = annehmen = questAccepted = true
            //        n = ablehnen = quest Accepted = false
            //        break;
            //    case 2:
            //        input->upgrades
            //        1 = upgrade1
            //        2 = upgrade2
            //        3 = upgrade3
            //        break;
            //}
        }

        /// <summary>
        /// zeichnen des rechtecks sowie der texte
        /// </summary>
        public virtual void Draw()
        {
            while (interactionPossible)
            {
                Game.WindowInstance().Draw(rectangle);
                Game.WindowInstance().Draw(text1);
                Game.WindowInstance().Draw(text2);
                Game.WindowInstance().Draw(text3);
                Game.WindowInstance().Draw(text4);
            }
        }
    }
}
