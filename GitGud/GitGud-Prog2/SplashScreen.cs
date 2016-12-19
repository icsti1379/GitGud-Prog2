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
        Texture splashTexture;
        Sprite splashSprite;
        
        public SplashScreen()
        {
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
        }

        public override GameStates Update()
        {
            return GameStates.SplashScreenState;
        }
    }
}
