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
    public class PauseMenu : State
    {
        private Text pauseMenuText1, pauseMenuText2;
        private Font pauseMenuFont;
        private Music pauseMenuMusic;
        private Texture pauseMenuBackground;
        private Sprite pauseMenuSprite;

        private GameStates targetState;

        public GameStates TargetState
        {
            get { return targetState;}
        }

        public PauseMenu()
        {
            pauseMenuMusic = new Music("Music/MainMenuSong.ogg");

            pauseMenuFont = new Font("Font/arial.ttf");
            pauseMenuText1 = new Text("Press 1 to continue the game.", pauseMenuFont, 28);
            pauseMenuText1.Position = new Vector2f(580, 380);
            
            pauseMenuText2 = new Text("Press 2 to return to the main menu.", pauseMenuFont, 28);
            pauseMenuText2.Position = new Vector2f(580, 420);

            pauseMenuBackground = new Texture("Pictures/mainmenu_background.jpg");
            pauseMenuSprite = new Sprite(pauseMenuBackground);
            
            targetState = GameStates.PauseMenuState;

            Initialize();
        }

        public override void Dispose()
        {
            
        }

        public override void Draw()
        {
            Game.WindowInstance().Draw(pauseMenuSprite);
        }

        public override void HandleInput(Keyboard.Key key, bool isPressed)
        {
            if (isPressed && (key == Keyboard.Key.Num1 || key == Keyboard.Key.Escape))
            {
               targetState = GameStates.GamePlayState;
            }
            else if (isPressed && key == Keyboard.Key.Num2)
            {
                targetState = GameStates.MainMenuState;
            }
        }

        public override void Initialize()
        {
            pauseMenuMusic.Play();
            pauseMenuMusic.Loop = true;

            targetState = GameStates.PauseMenuState;
        }
        
        public override GameStates Update()
        {
            // TODO CHECK BEFORE FINISH
            return targetState;
        }
    }
}
