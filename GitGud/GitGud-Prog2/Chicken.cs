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
    class Chicken : AnimatedCharacterWithAI
    {
        public Chicken() : base("Sprites/Other/chicken.png", 32)
        {
            // Define directions on spritesheet
            Anim_Up = new Animation(0, 0, 4);
            Anim_Left = new Animation(32, 0, 4);
            Anim_Down = new Animation(64, 0, 4);
            Anim_Right = new Animation(96, 0, 4);
        }
    }
}
