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
    class QuestNPC : AnimatedCharacter
    {
        public QuestNPC() : base("sprites/questNPC", 64)
        {
        }

        public override void Update(float deltaTime)
        {
            //while (Collision.Collision.Check(npcRect, playerPos))
            //    ->NPCinteraction;
            base.Update(deltaTime);
        }
    }
}
