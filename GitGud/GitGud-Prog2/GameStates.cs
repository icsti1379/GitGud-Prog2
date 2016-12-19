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

namespace GitGudP2
{
    public enum GameStates
    {
        UnspecifiedState = 0,
        SplashScreenState = 1,
        MainMenuState = 11,
        GamePlayState = 21,
        GPLevelState = 22,
        GameOverState = 25,
        CreditScreenState = 31,
        PauseMenuState = 41,
        QuitState = 99
    }
}
