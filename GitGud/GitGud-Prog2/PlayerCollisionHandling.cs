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
    class PlayerCollisionHandling
    {
        Player player;
        List<IntRect> colRectList;
        Vector2f playerPos;
        Vector2f playerColBoxTop;
        Vector2f playerColBoxRight;
        Vector2f playerColBoxBottom;
        Vector2f playerColBoxLeft;
        Collision collision;
        int offset;
        public PlayerCollisionHandling(Player player, List<IntRect> colRectList)
        {
            this.player = player;
            this.colRectList = colRectList;
            playerPos.X = player.Xpos;
            playerPos.Y = player.Ypos;
            offset = player.FrameSize;

            playerColBoxTop.X = playerPos.X + offset / 2;
            playerColBoxTop.Y = playerPos.Y;

            playerColBoxRight.X = playerPos.X + offset;
            playerColBoxRight.Y = playerPos.Y + offset / 2;

            playerColBoxBottom.X = playerPos.X + offset / 2;
            playerColBoxBottom.Y = playerPos.Y + offset;

            playerColBoxLeft.X = playerPos.X;
            playerColBoxLeft.Y = playerPos.Y + offset / 2;
        }

        public void Update()
        {
            
        }
    }
}
