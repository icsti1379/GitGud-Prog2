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
        Text text1;
        int identifier;
        string textContent;
        Font font;
        bool interactionPossible;

        public bool getiPossible()
        {
            return interactionPossible;
        }

        public void setiPossible(bool iPossible)
        {
            interactionPossible = iPossible;
        }

        public NPCinteraction(int identifier)
        {
            this.identifier = identifier;
            font = new Font("Font/arial.ttf");

            switch (identifier)
            {
                case 1:
                    textContent = "this is a quest Text";
                    break;
                case 2:
                    textContent = "this is an upgrade Text";
                    break;
            }

            text1 = new Text(textContent, font);
            text1.Position = new Vector2f(52, 52);

            rectangle = new RectangleShape(new Vector2f(400, 200));
            rectangle.Position = new Vector2f(50, 50);
            rectangle.FillColor = Color.Black;
            rectangle.OutlineColor = Color.Red;
            rectangle.OutlineThickness = 2;

            interactionPossible = true;
            //TODO: oberes rausnehmen wenn collision fertig integriert ist
        }
        public void Update()
        {
            switch (identifier)
            {
                case 1:
                    //input -> quest annehmen/ablehnen
                    //y = annehmen
                    //n = ablehnen
                    break;
                case 2:
                    //input -> upgrades
                    //1 = upgrade1
                    //2 = upgrade2
                    //3 = upgrade3
                    break;
            }
        }

        public void Draw(RenderWindow renderWindow)
        {
            while (interactionPossible)
            {
                renderWindow.Draw(rectangle);
                renderWindow.Draw(text1);
            }
        }
    }
}
