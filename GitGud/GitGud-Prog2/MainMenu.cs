using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;

namespace GitGudP2
{
    public class MainMenu : State
    {
        private Text mainMenuMessage1, mainMenuMessage2;
        private Font mainMenuFont;
        private Music mainMenuMusic;
        private Texture mainMenuBackground;
        private Sprite menuSprite;

        private GameStates targetState;
        
        public MainMenu()
        {
            mainMenuMusic = new Music("Music/MainMenuSong.ogg");

            mainMenuFont = new Font("Font/arial.ttf");
            mainMenuMessage1 = new Text("Press Enter to start the game.", mainMenuFont,64);
            mainMenuMessage1.Position = new Vector2f(300, 300);

            mainMenuMessage2 = new Text("Press C for credits screen.", mainMenuFont, 64);
            mainMenuMessage2.Position = new Vector2f(300, 480);

            mainMenuBackground = new Texture("Pictures/mainmenu_background.jpg");
            menuSprite = new Sprite(mainMenuBackground);

            Initialize();
        }
        public override void Dispose()
        {
            
        }


        public override void Initialize()
        {
           mainMenuMusic.Play();
           mainMenuMusic.Loop = true;
           targetState = GameStates.MainMenuState;
        }

        public override void Draw()
        {
            Game.WindowInstance().Draw(menuSprite);
            Game.WindowInstance().Draw(mainMenuMessage1);
            Game.WindowInstance().Draw(mainMenuMessage2);
        }

        public override void HandleInput(Keyboard.Key key, bool isPressed)
        {
            if (isPressed && key == Keyboard.Key.Return)
            {
                targetState = GameStates.GamePlayState;
            }

            else if (isPressed && key == Keyboard.Key.C)
            {
                targetState = GameStates.CreditScreenState;
            }
        }

        public override GameStates Update()
        {
            return targetState;
        }
    }
}
