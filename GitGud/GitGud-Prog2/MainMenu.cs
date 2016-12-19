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
        Text mainMenuMessage;
        private Music mainMenuMusic;

        public MainMenu()
        {
            mainMenuMusic = new Music("Music/MainMenuSong.wav");
            mainMenuMessage = new Text("Press Enter to start", new Font("Font/arial.ttf"));
            mainMenuMessage.Position = new Vector2f(50, 50);
            Initialize();
        }
        public override void Dispose()
        {
            //throw new notimplementedexception();
        }

        public override void Initialize()
        {
            mainMenuMusic.Play();
            //throw new notimplementedexception();
        }

        public override GameStates Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                return GameStates.GamePlayState;
            else
                return GameStates.MainMenuState;
            //throw new notimplementedexception();
        }

        public override void Draw(RenderWindow renderWindow)
        {
            mainMenuMessage = new Text("Press Enter to start", new Font("Font/arial.ttf"));
            mainMenuMessage.Position = new Vector2f(50, 50);
            renderWindow.Clear(Color.Black);
            renderWindow.Draw(mainMenuMessage);
            renderWindow.Display();
        }
    }
}
