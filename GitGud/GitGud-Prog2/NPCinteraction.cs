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
    class NPCinteraction
    {
        RectangleShape rectangle;
        protected Text text1, text2, text3, text4;
        protected string textContent;
        protected Font font;
        protected bool interactionPossible;
        protected Vector2f text1Pos, text2Pos, text3Pos, text4Pos;

        public bool getiPossible()
        {
            return interactionPossible;
        }

        public void setiPossible(bool iPossible)
        {
            interactionPossible = iPossible;
        }

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

        public virtual void Draw(RenderWindow renderWindow)
        {
            while (interactionPossible)
            {
                renderWindow.Draw(rectangle);
                renderWindow.Draw(text1);
                renderWindow.Draw(text2);
                renderWindow.Draw(text3);
                renderWindow.Draw(text4);
            }
        }
    }
}
