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
    class Collision
    {
        public bool IsColliding { get; set; }

        List<IntRect> colRectList;
        bool isColliding;
        IntRect colRect;
        Vector2f colVec;
        int colType;

        public Collision(IntRect rect, Vector2f pos)
        {
            this.colRect = rect;
            this.colVec = pos;
            colType = 1;
        }

        public Collision(List<IntRect> rectList, Vector2f pos)
        {
            this.colRectList = rectList;
            this.colVec = pos;
            colType = 2;
        }

        public void Update()
        {
            switch(colType)
            {
                case 1:
                    if (colRect.Contains((int)colVec.X, (int)colVec.Y))
                        isColliding = true;
                    break;
                case 2:
                    foreach (IntRect rect in colRectList)
                        if (rect.Contains((int)colVec.X, (int)colVec.Y))
                            isColliding = true;
                    break;
                default:
                    break;
            }
        }
    }
}
