using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GitGudP2
{
    public class CreditScreen : State
    {
        private Text creditScreenText, creditScreenText1, creditScreenText2;
        private Font creditScreenFont;

        private Texture creditScreen;
        private Sprite creditSprite;

        private GameStates targetState;

        public CreditScreen()
        {
            creditScreenFont = new Font("Font/8bitWonder.ttf");
            creditScreenText = new Text("CREDITSCREEN", creditScreenFont, 46);
            creditScreenText.Position = new Vector2f(550, 200);
            creditScreenText1 = new Text("Nikolas Pietrek.", creditScreenFont, 32);
            creditScreenText1.Position = new Vector2f(580, 360);

            creditScreenText2 = new Text("Benjamin Lehnert.", creditScreenFont, 32);
            creditScreenText2.Position = new Vector2f(580, 440);

            creditScreen = new Texture("Pictures/creditsscreen_background.jpg");
            creditSprite = new Sprite(creditScreen);

            targetState = GameStates.CreditScreenState;
        }
        public override void Dispose()
        {

        }

        public override void Draw()
        {
            Game.WindowInstance().Draw(creditScreenText);
            Game.WindowInstance().Draw(creditScreenText1);
            Game.WindowInstance().Draw(creditScreenText2);
            Game.WindowInstance().Draw(creditSprite);
        }

        public override void HandleInput(Keyboard.Key key, bool isPressed)
        {
            if(isPressed && (key == Keyboard.Key.Return || key == Keyboard.Key.Escape))
            {
                targetState = GameStates.MainMenuState;
            }
        }

        public override void Initialize()
        {
            targetState = GameStates.MainMenuState;
        }

        public override GameStates Update()
        {
            return targetState;
        }
    }
}
