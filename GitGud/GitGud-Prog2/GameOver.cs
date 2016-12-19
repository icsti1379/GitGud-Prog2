using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GitGudP2
{
    class GameOver : State
    {
        public GameOver()
        {

        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override GameStates Update()
        {
            //if (InputManager.Return)
            //    return GameStates.GamePlayState;
            //else
                return GameStates.GameOverState;
            throw new NotImplementedException();
        }
        public override void Draw(RenderWindow renderWindow)
        {
            renderWindow.Clear(Color.Green);
            renderWindow.Display();
            throw new NotImplementedException();
        }
    }
}
