using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitGudP2;
using SFML;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GitGud_Prog2
{
    public enum NormalTileType
    {
        Bricks = 1,
        Lava = 2,
        Black = 3,
        Gras = 4,
        Dirt = 5,
        GrassideTop = 6,
        GrassideBottom = 7,
        GrassideRight = 8,
        GrassideLeft = 9,
        GrassideTopleft = 10,
        GrassideTopright = 11,
        GrassideBotright = 12,
        GrassideBotleft = 13,
        GrassideCornerTopleft = 14,
        GrassideCornerTopright = 15,
        GrassideCornerBotright = 16,
        GrassideCornerBotleft = 17,
        Grey = 18,
        Brown = 19,
        StoneTop = 20,
        StoneBot = 21
    }

    public enum CollidableTileType
    {
        Wall = 1,
        Stone = 2,
        Tree1 = 3,
        Tree2 = 4,
        Water = 5,
        RiversideTop = 6,
        RiversideBottom = 7,
        RiversideRight = 8,
        RiversideLeft = 9,
        RiversideTopleft= 10,
        RiversideTopright = 11,
        RiversideBotright = 12,
        RiversideBotleft = 13,
        RiversideCornerTopleft = 14,
        RiversideCornerTopright = 15,
        RiversideCornerBotright = 16,
        RiversideCornerBotleft = 17,
    }
    public abstract class Tiles
    {
        public const int Width = 32;
        public const int Height = 32;

        protected Texture texture;
        protected Sprite sprite;
        protected Vector2f position;

        /// <summary>
        /// Getter for the position of a tile.
        /// </summary>
        public Vector2f Position
        {
            get { return position; }
        }

        /// <summary>
        /// Getter for the boundary rectangle of a tile.
        /// </summary>
        public FloatRect Rectangle
        {
            get { return sprite.GetGlobalBounds(); }
        }

        public Tiles()
        {

        }

        /// <summary>
        /// Initializes the sprite and the texture for the tile.
        /// </summary>
        virtual public void Initialize()
        {
            sprite = new Sprite();
            texture = new Texture(32, 32);
        }

        /// <summary>
        /// Draws the tile sprites.
        /// </summary>
        virtual public void Draw()
        {
            Game.WindowInstance().Draw(sprite);
        }
    }
}
