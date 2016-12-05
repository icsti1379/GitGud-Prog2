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

namespace SFML_Prog2_Gruppe1.States
{
    public class GamePlay : State
    {
        World world;
        Player player;
        QuestNPC questNPC;
        EnemyNPC enemyNPC;

        public GamePlay()
        {
            world = new World();
            player = new Player();
            questNPC = new QuestNPC();
            enemyNPC = new EnemyNPC();
        }

        public override void Dispose()
        {
           // throw new NotImplementedException();
        }

        public override void Draw()
        {
            world.Draw();
            player.Draw();
            questNPC.Draw();
            enemyNPC.Draw();
            //throw new NotImplementedException();
        }

        public override void Initialize()
        {
            //throw new NotImplementedException();
        }

        public override GameStates Update()
        {
            player.Update(world.CurrentRoom);
            return GameStates.GamePlayState;
            //throw new NotImplementedException();
        }

    }
}
