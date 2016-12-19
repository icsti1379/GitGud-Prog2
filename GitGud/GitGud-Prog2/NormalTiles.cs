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

namespace GitGud_Prog2
{
    class NormalTiles : Tiles
    {
        public NormalTiles(Vector2f position, NormalTileType type) : base()
        {
            Initialize();

            //TODO CORRECT TILE PATH
            switch (type)
            {
                case NormalTileType.Bricks:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(19 * 32, 7 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.Lava:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(11 * 32, 16 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.Black:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(17 * 32, 4 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.Grey:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(8 * 32, 23 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.Brown:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(7 * 32, 23 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.StoneTop:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(19 * 32, 14 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.StoneBot:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(20 * 32, 17 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.Dirt:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(19 * 32, 9 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.Gras:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(5 * 32, 9 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideLeft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(18 * 32, 9 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideTop:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(19 * 32, 8 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideRight:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(20 * 32, 9 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideBottom:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(19 * 32, 10 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideBotleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(18 * 32, 10 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideBotright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(20 * 32, 10 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideTopleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(18 * 32, 8 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideTopright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(20 * 32, 8 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideCornerBotleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(19 * 32, 7 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideCornerBotright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(20 * 32, 7 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideCornerTopright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(20 * 32, 6 * 32), new Vector2i(32, 32)));
                    break;

                case NormalTileType.GrassideCornerTopleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(19 * 32, 6 * 32), new Vector2i(32, 32)));
                    break;


            }
            this.position = position;

            sprite.Texture = texture;
            sprite.Position = position;
        }
    }
}
