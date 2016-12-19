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
    class CollidableTiles : Tiles
    {
        IntRect colRect;
        public CollidableTiles(Vector2f position, CollidableTileType type) : base()
        {
            Initialize();

            //TODO CORRECT TILE PATH
            switch (type)
            {
                case CollidableTileType.Wall:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;

                case CollidableTileType.Stone:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;

                case CollidableTileType.Tree1:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;

                case CollidableTileType.Tree2:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;

                case CollidableTileType.Water:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(7*32, 15*32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideBottom:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(8*32, 15*32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideLeft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(7*32, 14*32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideTop:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(6*32, 15*32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideRight:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(7*32, 16*32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideTopleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(6 * 32, 14 * 32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideTopright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(6 * 32, 16 * 32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideBotright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(8 * 32, 16 * 32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideBotleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(8 * 32, 14 * 32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideCornerTopleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(7 * 32, 12 * 32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideCornerTopright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(8 * 32, 12 * 32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideCornerBotright:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(8 * 32, 13 * 32), new Vector2i(32, 32)));
                    break;

                case CollidableTileType.RiversideCornerBotleft:
                    texture = new Texture("Maps/terrain.png", new IntRect(new Vector2i(7 * 32, 13 * 32), new Vector2i(32, 32)));
                    break;
            }
            this.position = position;

            sprite.Texture = texture;
            sprite.Position = position;

            colRect = new IntRect((int)position.X, (int)position.Y, 32, 32);
        }
    }
}
