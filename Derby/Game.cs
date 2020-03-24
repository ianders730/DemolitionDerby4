using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Derby
{
    public class Game
    {
        private int numberOpponents = 2;
        public Car Player { get; set; }
        public List<Car> Opponents { get; set; }

        private void InitializeGame()
        {
            Player = new Car(600);
            Player.StartEngine();
            Opponents = new List<Car>();
            for (int i = 0; i < numberOpponents; i++)
            {
                Car opponent = new Car(600);
                opponent.StartEngine();
                Opponents.Add(opponent);
            }

        }

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
                foreach (var opponent in Opponents)
                {
                    opponent.Display();
                }
                invalidated = false;
            }
        }

        private DateTime gameTime = DateTime.Now;
        private void UpdateGame()
        {
            int updateInterval = 2000; // 1/2 a second
            if (DateTime.Now.Subtract(gameTime) >
                TimeSpan.FromMilliseconds(updateInterval))
            {
                for (int i = 0; i < Opponents.Count; i++)
                {
                    Opponents[i].MakeRandomMovement();
                }
                //for (int i = Opponents.Count - 1; i >= 0; i--)
                //{
                //    if (Player.LocationX == Opponents[i].LocationX &&
                //           Player.LocationY == Opponents[i].LocationY)
                //    {
                //        // Player collides with Opponent
                //        Opponents.Remove(Opponents[i]);
                //    }
                //}

                var crashes = from car in Opponents
                              where car.LocationX == Player.LocationX &&
                              car.LocationY == Player.LocationY
                              select car;

                var crashList = crashes.ToList();
                foreach (var car in crashList)
                {
                    Opponents.Remove(car);
                }

                if (Opponents.Count == 0)
                {
                    isPlaying = false;
                }
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
