using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitGudP2
{
    public class InputManager
    {
        private CharacterState CurrentState;

        public void InputHandler()
        {
            this.CurrentState = CharacterState.None;

            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                this.CurrentState = CharacterState.MovingRight;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                this.CurrentState = CharacterState.MovingLeft;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                this.CurrentState = CharacterState.MovingUp;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                this.CurrentState = CharacterState.MovingDown;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
            {
                
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {

            }
        }
    }
}

/*  
     this.CurrentState = CharacterState.None;

        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        {
            this.CurrentState = CharacterState.MovingRight;
        }
        
         



  if (Keyboard.IsKeyPressed(Keyboard.Key.W) && !up)
     {
         vCharacterPosition.Y -= fCharacterVelocity;
         bMovingUp = true;
     }

     if (Keyboard.IsKeyPressed(Keyboard.Key.S) && !down)
     {
         vCharacterPosition.Y += fCharacterVelocity;
         bMovingDown = true;
     }

     if (Keyboard.IsKeyPressed(Keyboard.Key.A) && !left)
     {
         vCharacterPosition.X -= fCharacterVelocity;
         bMovingLeft = true;
     }

     if (Keyboard.IsKeyPressed(Keyboard.Key.D) && !right)
     {
         vCharacterPosition.X += fCharacterVelocity;
         bMovingRight = true;
     }

     vMousePosition = Mouse.GetPosition(window);

     if (Mouse.IsButtonPressed(Mouse.Button.Left) && !bPressed)
     {
         Shoot = true;
         bPressed = true;
     }
     else if (!Mouse.IsButtonPressed(Mouse.Button.Left))
         bPressed = false;
 }*/

/* Mouse direction
    protected void PlayerRotation()
    {
        // Calculating Mouse Position using the Character Position as Origin
        vMousePositionFromPlayer = (Vector2i)CharacterPosition + new Vector2i(25,25) - Input.vMousePosition;


        // Calculating Angle of the Mouse Position relative to the Character
        iAngle = (float)Math.Acos(      (vMousePositionFromPlayer.X    *   0     +     vMousePositionFromPlayer.Y   *   1)  /
                                        (Math.Sqrt(    Math.Pow(vMousePositionFromPlayer.X, 2)   +   Math.Pow(vMousePositionFromPlayer.Y, 2)   )        *       Math.Sqrt(    Math.Pow(0, 2)   +   Math.Pow(1, 2)    )    ));

        iAngle = (iAngle / (float)Math.PI * 180);

        if (vMousePositionFromPlayer.X > 0)
            iAngle = 360 - iAngle;


        // Rotating Character
        sEntity.Origin = new Vector2f(25,25);
        sEntity.Rotation = iAngle;
    }*/

