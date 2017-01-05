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
        Clock clock;
        private Texture splashTexture;
        private Sprite splashSprite;
        private Text splashScreenMessage;
        private Font splashScreenFont;

        public SplashScreen()
        {
            splashScreenFont = new Font("Font/8bitWonder.ttf");
            splashScreenMessage = new Text("GitGudP2", splashScreenFont, 128);
            splashScreenMessage.Position = new Vector2f(400, 320);

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
        }

        public override void HandleInput(Keyboard.Key key, bool isPressed)
        {
            
        }

        public override void Draw()
        {
            Game.WindowInstance().Draw(splashSprite);
            Game.WindowInstance().Draw(splashScreenMessage);
        }

        public override GameStates Update()
        {
            if (clock.ElapsedTime.AsSeconds() >= 3f)
            {
                return GameStates.MainMenuState;
            }
            return GameStates.SplashScreenState;
        }
    }
}
