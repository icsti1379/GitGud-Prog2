﻿using System;
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
    public class SplashScreen : State
    {
        Clock clock;

        public SplashScreen()
        {
            Initialize();
        }


        public override void Dispose()
        {
            //throw new NotImplementedException();
        }

        public override void Draw()
        {
            ProjectRenderWindow.GetRenderWindowInstance().Clear(Color.Blue);
        }

        public override void Initialize()
        {
            clock = new Clock();
            clock.Restart();
        }

        public override GameStates Update()
        {
            if(clock.ElapsedTime.AsSeconds() >= 1f)
            {
                return GameStates.GamePlayState;
            }
            return GameStates.SplashScreenState;
        }
    }
}
