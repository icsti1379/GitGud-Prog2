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
                case NormalTileType.tile1:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;

                case NormalTileType.tile2:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;

                case NormalTileType.tile3:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;

                case NormalTileType.tile4:
                    texture = new Texture("path-to-tilesheet_and-id");
                    break;
            }
            this.position = position;

            sprite.Texture = texture;
            sprite.Position = position;
        }
    }
}
