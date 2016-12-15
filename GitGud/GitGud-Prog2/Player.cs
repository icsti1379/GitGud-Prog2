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
    class Player : AnimatedCharacter
    {
        Vector2f playerPos;
        public Player() : base("Sprites/male_01.png", 64)
        {
            Anim_Up = new Animation(512, 0, 9);
            Anim_Left = new Animation(578, 0, 9);
            Anim_Down = new Animation(640, 0, 9);
            Anim_Right = new Animation(704, 0, 9);

            moveSpeed = 150;
            animationSpeed = 0.05f;
        }
        public override void Update(float deltaTime)
        {

            this.CurrentState = CharacterState.None;

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.CurrentState = CharacterState.MovingRight;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.CurrentState = CharacterState.MovingLeft;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                this.CurrentState = CharacterState.MovingUp;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                this.CurrentState = CharacterState.MovingDown;
            }

            base.Update(deltaTime);
        }
    }
}
