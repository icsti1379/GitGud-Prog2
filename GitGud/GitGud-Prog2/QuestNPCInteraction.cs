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
    /// Klasse für die Interaktion mit Quest NPC
    /// </summary>
    class QuestNPCInteraction : NPCinteraction
    {
        bool questAccepted;

        /// <summary>
        /// getter, der zurück gibt, ob die Quest angenommen wurde
        /// </summary>
        /// <returns></returns>
        public bool QuestAccepted()
        {
            return questAccepted;
        }

        /// <summary>
        /// Konstruktor, erstellt die Texte
        /// </summary>
        public QuestNPCInteraction() : base()
        {
            textContent = "Dies ist ein Quest text";
            text1 = new Text(textContent, font);
            text1.Position = text1Pos;
            textContent = "er geht weiter";
            text2 = new Text(textContent, font);
            text2.Position = text2Pos;
            textContent = "und weiter";
            text3 = new Text(textContent, font);
            text3.Position = text3Pos;
            textContent = "Annehmen? Y/N";
            text4 = new Text(textContent, font);
            text4.Position = text2Pos;
        }

        /// <summary>
        /// update schaut ob die quest angenommen wurde oder nicht
        /// falls ja wird das level gestartet
        /// </summary>
        public override void Update()
        {
            //if (InputManager.Y)
            //    questAccepted = true;
            //if (InputManager.N)
            //    questAccepted = false;

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
