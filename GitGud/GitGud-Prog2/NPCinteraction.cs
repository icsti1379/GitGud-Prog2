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
                    textContent = "this is an upgrade Test";
                    break;
            }

            text1 = new Text(textContent, font);
            text1.Position = new Vector2f(52, 52);

            rectangle = new RectangleShape(new Vector2f(400, 200));
            rectangle.Position = new Vector2f(50, 50);
            rectangle.FillColor = Color.Black;
            rectangle.OutlineColor = Color.Red;
            rectangle.OutlineThickness = 2;
        }
        public void Update()
        {
            //if (identifier == "Quest")
            //{
                
            //}

            //if (identifier == "Upgrade")
            //{
                
            //}

            //else
            //    throw NotImplementedException;
        }

        public void Draw(RenderWindow renderWindow)
        {
            renderWindow.Draw(rectangle);
            renderWindow.Draw(text1);
            //if (identifier == "Quest")
            //{
            //    renderWindow.Draw(rectangle);
            //    renderWindow.Draw(text1);
            //}

            //if (identifier == "Upgrade")
            //{
            //    renderWindow.Draw(rectangle);
            //    renderWindow.Draw(text1);
            //}

            //else
            //    renderWindow.Draw(rectangle);
        }
    }
}
