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
    public class SplashScreen : State
    {
        //COMMIT: Added key input to skip SplashScreen State
        //COMMIT: Changed ScreenText Position
        Clock clock;
        private Texture splashTexture;
        private Sprite splashSprite;
        private Text splashScreenText;
        private Font splashScreenFont;

        private GameStates currentState;


        private bool kipSkip;

        public SplashScreen()
        {
            splashScreenFont = new Font("Font/8bitWonder.ttf");
            splashScreenText = new Text("GitGudP2", splashScreenFont, 100);
            splashScreenText.Position = new Vector2f(270, 320);

            splashTexture = new Texture("Pictures/splashscreen.png");
            splashSprite = new Sprite(splashTexture);

            Initialize();
        }

        public override void Dispose()
        {
           
        }

        public override void Initialize()
        {
            clock = new Clock();
            clock.Restart();
            
            
            currentState = GameStates.SplashScreenState;
        }

        public override void HandleInput(Keyboard.Key key, bool isPressed)
        {
            if (isPressed && (key == Keyboard.Key.Escape || key == Keyboard.Key.Return))
            {
                kipSkip = true;
            }
        }

        public override void Draw()
        {
            Game.WindowInstance().Draw(splashSprite);
            Game.WindowInstance().Draw(splashScreenText);
        }

        public override GameStates Update()
        {
            if (clock.ElapsedTime.AsSeconds() >= 5f || kipSkip)
            {
                return GameStates.MainMenuState;
            }
            return currentState;
        }
    }
}
