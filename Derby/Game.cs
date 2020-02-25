using System;
using System.Collections.Generic;
using System.Text;

namespace Derby
{
    public class Game
    {
        public Car Player { get; set; }

        public void Run()
        {
            //Console.Write("Enter tank capacity: ");
            //double capacity = double.Parse(Console.ReadLine());
            //Player = new Car(capacity);
            //Player.StartEngine();
            //Player.Accelerate();
            //Player.TurnLeft();
            //Player.TurnLeft();
            //Player.TurnRight();
            DrawMap(24, 79);
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
