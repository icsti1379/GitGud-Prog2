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
    public abstract class State
    {
        public abstract void Initialize();

        public abstract GameStates Update();

        public abstract void Draw(RenderWindow renderWindow);

        public abstract void Dispose();
    }
}
