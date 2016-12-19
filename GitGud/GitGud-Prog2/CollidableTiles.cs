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
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;
            }
            this.position = position;

            sprite.Texture = texture;
            sprite.Position = position;
        }
    }
}
