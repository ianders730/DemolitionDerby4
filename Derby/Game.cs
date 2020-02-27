using System;
using System.Collections.Generic;
using System.Text;

namespace Derby
{
    public class Game
    {
        public Car Player { get; set; }
        public Car Opponent { get; set; }

        public void Run()
        {
            DrawMap(24, 79);
            Player = new Car(600);
            Player.StartEngine();
            Player.Display();
            Opponent = new Car(600);
            Opponent.StartEngine();
            Opponent.Display();
            //Player.Accelerate();
            //Player.TurnLeft();
            //Player.TurnLeft();
            //Player.TurnRight();
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
