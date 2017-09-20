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

        // Define map size
        int mapWidth = 20;
        int mapHeight = 20;

        List<IntRect> collisionList = new List<IntRect>();
        List<int> collisionTiles = new List<int>() { 366, 367, 368, 355, 291 };

        public List<IntRect> getTerrainColList()
        {
            return collisionList;
        }

        public Map(int tilemapW, int tilemapH)
        {
            int tilemapWidth = tilemapW;
            int tilemapHeight = tilemapH;
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
            StreamReader reader = new StreamReader("Maps/hub_map.csv");

            for(int y = 0; y < mapHeight; y++)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                for (int x = 0; x < mapWidth; x++)
                {
                    int id = Convert.ToInt32(items[x]);
                    if (collisionTiles.Contains(id))
                        collisionList.Add(new IntRect(new Vector2i(tileSize * x, tileSize * y), new Vector2i(32, 32)));

                    tiles[x , y] = new Sprite(tilemap[id]);
                    tiles[x, y].Position = new Vector2f(tileSize * x, tileSize * y);
                }
            }
            reader.Close();
        }

        public void Draw()
        {
            for(int y = 0; y < mapHeight; y++)
            {
                for(int x = 0; x < mapWidth; x++)
                {
                    Game.WindowInstance().Draw(tiles[x , y]);
                }
            }
        }
    }
}
