﻿using System;
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
    class QuestNPC : AnimatedCharacter
    {
        IntRect interactionRect;
        Vector2f position;
        NPCinteraction questNPCInteraction;
        public QuestNPC() : base("sprites/questNPC", 64)
        {
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
