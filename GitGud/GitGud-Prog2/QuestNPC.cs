using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GitGudP2
{
    /// <summary>
    /// Quest NPC basisklasse
    /// </summary>
    class QuestNPC : AnimatedCharacter
    {
        IntRect interactionRect;
        Vector2f position;
        NPCinteraction questNPCInteraction;
        public QuestNPC() : base("Sprites/NPC/questNPC.png", 64)
        {
            Anim_Up = new Animation(512, 0, 9);
            Anim_Left = new Animation(578, 0, 9);
            Anim_Down = new Animation(640, 0, 9);
            Anim_Right = new Animation(704, 0, 9);

            interactionRect = new IntRect((int)position.X - 5, (int)position.Y - 5, 74, 74);
            questNPCInteraction = new QuestNPCInteraction();
        }

        public override void Update(float deltaTime)
        {

            //if (Collision.Collision.Check(interactionRect, playerPos))
            //    npcInteraction.setiPossible(true);
            //else
            //    npcInteraction.setiPossible(false);
            //base.Update(deltaTime);
        }
    }
}
