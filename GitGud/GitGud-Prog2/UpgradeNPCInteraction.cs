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
    /// Klasse für die Interaktion mit dem Upgrade NPC
    /// </summary>
    class UpgradeNPCInteraction : NPCinteraction
    {
        bool lifeUpgrade, runSpeedUpgrade, doubleScoreUpgrade;

        /// <summary>
        /// getter für das lifeupgrade
        /// </summary>
        /// <returns></returns>
        public bool LifeUpgrade()
        {
            return lifeUpgrade;
        }

        /// <summary>
        /// getter für das runspeed Upgrade
        /// </summary>
        /// <returns></returns>
        public bool RunSpeedUpgrade()
        {
            return runSpeedUpgrade;
        }

        /// <summary>
        /// getter für das score upgrade
        /// </summary>
        /// <returns></returns>
        public bool DoubleScoreUpdate()
        {
            return doubleScoreUpgrade;
        }

        /// <summary>
        /// Konstruktor, erstellt die texte und setzt die upgrade bools standartmäßig auf false
        /// </summary>
        public UpgradeNPCInteraction() : base()
        {
            textContent = "Upgrade1: 5C";
            text1 = new Text(textContent, font);
            text1.Position = text1Pos;
            textContent = "Upgrade2: 10C";
            text2 = new Text(textContent, font);
            text2.Position = text2Pos;
            textContent = "Upgrade3: 20C";
            text3 = new Text(textContent, font);
            text3.Position = text3Pos;
            textContent = "Y/N";
            text4 = new Text(textContent, font);
            text4.Position = text2Pos;

            lifeUpgrade = false;
            runSpeedUpgrade = false;
            doubleScoreUpgrade = false;
        }

        /// <summary>
        /// überprüft, ob der Spieler ein Upgrade gekauft hat
        /// </summary>
        public override void Update()
        {
            //if (InputManager.1)
            //      if (player.coins >=5)
            //          upgrade1 = true;
            //      else
            //          upgrad1 = false;
            //if (InputManager.2)
            //      if (player.coins >=10)
            //          upgrade1 = true;
            //      else
            //          upgrad1 = false;
            //if (InputManager.3)
            //      if (player.coins >=15)
            //          upgrade1 = true;
            //      else
            //          upgrad1 = false;
            //else
            //{
            //    upgrade1 = false;
            //    upgrade2 = false;
            //    upgrade3 = false;
            //}

            base.Update();
        }

        public override void Draw(RenderWindow renderWindow)
        {
            base.Draw(renderWindow);
        }
    }
}
