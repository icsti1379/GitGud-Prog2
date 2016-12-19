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
    class Interface
    {
        int playerLife, playerScore, playerPoints, questCount;
        RectangleShape rectangle;
        Text lifeText, scoreText, pointsText, questText;
        string textContentLife, textContentScore, textContentPoints, textContentQuest;
        Font font;

        public void SetPlayerLife(int life)
        {
            playerLife = life;
        }

        public void SetPlayerScore(int score)
        {
            playerScore = score;
        }

        public void SetPlayerPoints(int points)
        {
            playerPoints = points;
        }

        public void SetQuestCount(int count)
        {
            questCount = count;
        }
        public Interface()
        {
            rectangle = new RectangleShape(new Vector2f(1280,50));
            rectangle.Position = new Vector2f(0, 750);
            rectangle.FillColor = new Color(100, 100, 100);
            rectangle.OutlineColor = Color.Red;
            font = new Font("Font/arial.ttf");
            lifeText = new Text(textContentLife, font);
            lifeText.Color = Color.Black;
            lifeText.Position = new Vector2f(50, 780);
            scoreText = new Text(textContentScore, font);
            scoreText.Color = Color.Black;
            scoreText.Position = new Vector2f(1000, 760);
            pointsText = new Text(textContentPoints, font);
            pointsText.Color = Color.Black;
            pointsText.Position = new Vector2f(1000, 780);
            questText = new Text(textContentQuest, font);
            questText.Color = Color.Black;
            questText.Position = new Vector2f(50, 760);
        }

        public void Update()
        {
            textContentLife = "Life : " + playerLife.ToString();
            textContentScore = "Score : " + playerScore.ToString();
            textContentPoints = "Points : " + playerPoints.ToString();
            textContentQuest = "Remaining Monsters to kill : " + questCount.ToString();
        }

        public void Draw(RenderWindow renderWindow)
        {
            renderWindow.Draw(rectangle);
            renderWindow.Draw(lifeText);
            renderWindow.Draw(scoreText);
            renderWindow.Draw(pointsText);
            renderWindow.Draw(questText);
        }
    }
}
