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
         public Player() : base("Sprites/Characters/warrior.png", 64)
        {
            // Define directions on spritesheet
            Anim_Up = new Animation(512, 0, 9);
            Anim_Left = new Animation(578, 0, 9);
            Anim_Down = new Animation(640, 0, 9);
            Anim_Right = new Animation(704, 0, 9);

            // Set moving and animation speed
            moveSpeed = 200;
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

        //protected void PlayerRotation()
        //{
        //    // Calculating Mouse Position using the Character Position as Origin
        //    vMousePositionFromPlayer = (Vector2i)CharacterPosition + new Vector2i(25, 25) - Input.vMousePosition;


        //    // Calculating Angle of the Mouse Position relative to the Character
        //    iAngle = (float)Math.Acos((vMousePositionFromPlayer.X * 0 + vMousePositionFromPlayer.Y * 1) /
                                            //(Math.Sqrt(Math.Pow(vMousePositionFromPlayer.X, 2) + Math.Pow(vMousePositionFromPlayer.Y, 2)) * Math.Sqrt(Math.Pow(0, 2) + Math.Pow(1, 2))));

        //    iAngle = (iAngle / (float)Math.PI * 180);

        //    if (vMousePositionFromPlayer.X > 0)
        //        iAngle = 360 - iAngle;


        //    // Rotating Character
        //    sEntity.Origin = new Vector2f(25, 25);
        //    sEntity.Rotation = iAngle;
        //}
    }
}
