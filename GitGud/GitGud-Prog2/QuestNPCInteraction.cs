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
    class QuestNPCInteraction : NPCinteraction
    {
        bool questAccepted;
        public bool QuestAccepted()
        {
            return questAccepted;
        }

        public QuestNPCInteraction() : base()
        {
            textContent = "Dies ist ein Quest text";
            text1 = new Text(textContent, font);
            text1.Position = text1Pos;
            textContent = "Y/N";
            text4 = new Text(textContent, font);
            text4.Position = text2Pos;
        }

        public override void Update()
        {
            //if (InputManager.Y)
            //    questAccepted = true;
            //if (InputManager.N)
            //    questAccepted = false;

            base.Update();
        }

        public override void Draw(RenderWindow renderWindow)
        {
            base.Draw(renderWindow);
        }
    }
}
