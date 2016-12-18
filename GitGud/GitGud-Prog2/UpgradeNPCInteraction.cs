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
    class UpgradeNPCInteraction : NPCinteraction
    {
        bool lifeUpgrade, runSpeedUpgrade, doubleScoreUpgrade;

        public bool LifeUpgrade()
        {
            return lifeUpgrade;
        }

        public bool RunSpeedUpgrade()
        {
            return runSpeedUpgrade;
        }

        public bool DoubleScoreUpdate()
        {
            return doubleScoreUpgrade;
        }

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

        public override void Update()
        {
            //if (InputManager.1)
            //    upgrade1 = true;
            //if (InputManager.2)
            //    upgrade2 = true;
            //if (InputManager.3)
            //    upgrade3 = true;
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
