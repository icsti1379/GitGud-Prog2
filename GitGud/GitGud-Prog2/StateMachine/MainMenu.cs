using System;
using System.Collections.Generic;
using System.Data.Common;
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
        //TODO: Refactor useless code
        //TODO: Write commits
        private Text mainMenuText, mainMenuText1, mainMenuText2;
        private Font mainMenuFont;
        //private Music mainMenuMusic;
        private Texture mainMenuBackground;
        private Sprite menuSprite;

        private GameStates targetState;
        
        public MainMenu()
        {
            //mainMenuMusic = new Music("Music/MainMenuSong.ogg");
            
            mainMenuFont = new Font("Font/8bitWonder.ttf");
            mainMenuText = new Text("Main menu", mainMenuFont, 64);
            mainMenuText.Position = new Vector2f(360, 60);

            mainMenuText1 = new Text("Press Enter to start the game", mainMenuFont,32);
            mainMenuText1.Position = new Vector2f(230, 230);

            mainMenuText2 = new Text("Press C for credits screen", mainMenuFont, 32);
            mainMenuText2.Position = new Vector2f(230, 280);

            mainMenuBackground = new Texture("Pictures/mainmenu_background.jpg");
            menuSprite = new Sprite(mainMenuBackground);

            Initialize();
        }
        public override void Dispose()
        {
            
        }

        public override void Initialize()
        {
            //if (targetState == GameStates.MainMenuState)
            //{
            //    mainMenuMusic.Play();
            //    mainMenuMusic.Loop = false;
            //}

            targetState = GameStates.MainMenuState;
        }

        public override void Draw()
        {
            Game.WindowInstance().Draw(menuSprite);
            Game.WindowInstance().Draw(mainMenuText);
            Game.WindowInstance().Draw(mainMenuText1);
            Game.WindowInstance().Draw(mainMenuText2);
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

            else if (isPressed && key == Keyboard.Key.Escape)
            {
                targetState = GameStates.QuitState;
            }
        }

        public override GameStates Update()
        {
            return targetState;
        }
    }
}
