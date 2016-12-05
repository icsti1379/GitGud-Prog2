using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;

namespace GitGudP2
{
    class Map
    {
        Sprite[,] tiles;
        int mapWidth = 100;
        int mapHeight = 100;

        public Map()
        {
            int tilemapWidth = 21;
            int tilemapHeight = 23;
            int tileSize = 32;

            Texture texture = new Texture("Maps/terrain.png");
            Sprite[] tilemap = new Sprite[tilemapWidth * tilemapHeight];

            for(int y = 0; y < tilemapHeight; y++)
            {
                for(int x = 0; x < tilemapWidth; x++)
                {
                    IntRect rect = new IntRect(x * tileSize, y * tileSize, tileSize, tileSize);
                    tilemap[(y * tilemapWidth) + x] = new Sprite(texture, rect);
                }
            }

            tiles = new Sprite[mapWidth, mapHeight];
            StreamReader reader = new StreamReader("Maps/test.csv");

            for(int y = 0; y < mapHeight; y++)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                for (int x = 0; x < mapWidth; x++)
                {
                    int id = Convert.ToInt32(items[x]);
                    tiles[x , y] = new Sprite(tilemap[id]);
                    tiles[x, y].Position = new Vector2f(tileSize * x, tileSize * y);
                }
            }

            reader.Close();
        }

        public void Draw(RenderWindow window)
        {
            for(int y = 0; y < mapHeight; y++)
            {
                for(int x = 0; x < mapWidth; x++)
                {
                    window.Draw(tiles[x , y]);
                }
            }
        }
    }
}
