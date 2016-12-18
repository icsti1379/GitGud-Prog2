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
    /// <summary>
    /// Player Grundklasse
    /// </summary>
    class Player : AnimatedCharacter
    {
        //TODO: überall wo playerposition verwendet wird, muss diese erst von tilemap pos auf normal pos umgerechnet werden
        // überlegen wie score in coins umgerechnet wird
        //movespeedupgrade auf movespeed anwenden
        Vector2f playerPos;
        bool quest, hasFired;
        int score, life, runSpeed;
        bool doubleScore;

        /// <summary>
        /// nachfolgend mehrere setter und getter für verschiedene Attribute des Spielers
        /// benötigt für Upgrades, Collision und andere sachen
        /// </summary>
        /// <returns></returns>
        public int GetLife()
        {
            return life;
        }

        public void SetLife(int life)
        {
            this.life = life;
        }
        public void SetLife(bool lifeIncreased)
        {
            if (lifeIncreased)
                life++;
        }

        public int GetRunSpeed()
        {
            return runSpeed;
        }

        public void SetRunSpeed(int multiplier)
        {
            runSpeed = runSpeed * multiplier;
        }

        public bool GetDoubleScore()
        {
            return doubleScore;
        }

        public void SetDoubleScore(bool doubleScore)
        {
            this.doubleScore = doubleScore;
        }

        public int GetPlayerScore()
        {
            return score;
        }

        public void IncreasePlayerScore(bool scoreIncrease)
        {
            score++;
        }
        public Vector2f getPlayerPos()
        {
            return playerPos;
        }

        public void setPlayerPos(Vector2f pos)
        {
            playerPos = pos;
        }

        public bool HasFired()
        {
            return hasFired;
        }

        public bool Quest { get; set; }
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
            hasFired = false;

            //falls life zu hoch ist auf max wert setzen
            if (life > 5)
                life = 5;

            //regelt was bei doublescore passiert
            if (!doubleScore)
                score++;
            if (doubleScore)
                score += 2;
            //if mouseclock -> hasFired = true;
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
