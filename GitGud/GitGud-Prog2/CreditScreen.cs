using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
        //COMMIT: Added key inputs to return back to main menu
        //COMMIT: Added timer which return automaticly back to main menu
        //COMMIT: Changed font size and position
        private Clock clock;
        private Text creditScreenText, creditScreenText1, creditScreenText2;
        private Font creditScreenFont;

        private Texture creditScreen;
        private Sprite creditSprite;

        private bool kipBack;

        private GameStates currentState;

        public CreditScreen()
        {
            creditScreenFont = new Font("Font/8bitWonder.ttf");
            creditScreenText = new Text("CREDITSCREEN", creditScreenFont, 60);
            creditScreenText.Position = new Vector2f(310, 125);
            creditScreenText1 = new Text("Nikolas Pietrek", creditScreenFont, 32);
            creditScreenText1.Position = new Vector2f(400, 260);

            creditScreenText2 = new Text("Benjamin Lehnert", creditScreenFont, 32);
            creditScreenText2.Position = new Vector2f(400, 340);

            creditScreen = new Texture("Pictures/creditsscreen_background.jpg");
            creditSprite = new Sprite(creditScreen);

            Initialize();
        }

        public override void Dispose()
        {

        }

        public override void Initialize()
        {
            clock = new Clock();
            clock.Restart();

            kipBack = false;

            currentState = GameStates.CreditScreenState;
        }

        public override void HandleInput(Keyboard.Key key, bool isPressed)
        {
            if (isPressed && (key == Keyboard.Key.Return || key == Keyboard.Key.Escape))
            {
                kipBack = true;
            }
        }

        public override void Draw()
        {
            Game.WindowInstance().Draw(creditSprite);
            Game.WindowInstance().Draw(creditScreenText);
            Game.WindowInstance().Draw(creditScreenText1);
            Game.WindowInstance().Draw(creditScreenText2);
        }

        public override GameStates Update()
        {
            if ((clock.ElapsedTime.AsSeconds() >= 5f) || kipBack == true)
            {
                return GameStates.MainMenuState;
            }

            return currentState;
        }
    }
}