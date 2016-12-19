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
        tile1 = 1,
        tile2 = 2,
        tile3 = 3,
        tile4 = 4,
    }

    public enum CollidableTileType
    {
        Wall = 1,
        Stone = 2,
        Tree1 = 3,
        Tree2 = 4,
        Water = 5,
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

        public Tile()
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
