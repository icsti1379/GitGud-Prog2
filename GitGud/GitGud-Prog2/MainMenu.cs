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
        public override void Dispose()
        {
            //throw new notimplementedexception();
        }

        public override void Initialize()
        {
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
            renderWindow.Clear(Color.Black);
            renderWindow.Display();
        }
    }
}
