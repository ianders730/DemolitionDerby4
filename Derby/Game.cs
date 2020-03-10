using System;
using System.Collections.Generic;
using System.Text;

namespace Derby
{
    public class Game
    {
        public Car Player { get; set; }
        public Car Opponent { get; set; }

        private bool isPlaying = true;

        public void Run()
        {
            InitializeGame();
            do
            {
                ProcessInput();
                UpdateGame();
                RenderOutput();
            } while (isPlaying);
        }

        private void RenderOutput()
        {
            if (invalidated)
            {
                Console.Clear();
                DrawMap(24, 79);
                Player.Display();
                Opponent.Display();
                invalidated = false;
            }
        }

        private DateTime gameTime = DateTime.Now;
        private void UpdateGame()
        {
            int updateInterval = 500; // 1/2 a second
            if (DateTime.Now.Subtract(gameTime) > 
                TimeSpan.FromMilliseconds(updateInterval))
            {
                Opponent.MakeRandomMovement();
                invalidated = true;
                gameTime = DateTime.Now;
            }
        }

        private bool invalidated = true;
        private void ProcessInput()
        {
            ConsoleKeyInfo keyInfo;
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Player.Accelerate();
                        invalidated = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        Player.TurnLeft();
                        invalidated = true;
                        break;
                    case ConsoleKey.RightArrow:
                        Player.TurnRight();
                        invalidated = true;
                        break;
                    case ConsoleKey.Q:
                        isPlaying = false;
                        break;
                }
            }
        }


        private void InitializeGame()
        {
            Player = new Car(600);
            Player.StartEngine();
            Opponent = new Car(600);
            Opponent.StartEngine();
        }

        public void DrawMap(int height, int width)
        {
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (row == 0 || column == 0 ||
                        row == height - 1 || column == width - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
