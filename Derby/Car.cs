using System;
using System.Collections.Generic;
using System.Text;

namespace Derby
{
    public class Car
    {
        private static int carCount = 0;
        private int carNumber;
        private static Random randomGenerator = new Random();

        public bool Visible { get; set; }
        private int locationX;

        public int LocationX
        {
            get { return locationX; }
            set
            {
                if (value > 0 && value < 79)
                {
                    locationX = value;
                }
            }
        }

        private int locationY;

        public int LocationY
        {
            get { return locationY; }
            set
            {
                if (value > 0 && value < 24)
                {
                    locationY = value;
                }
            }
        }

        public double TankCapacity { get; set; }
        //public double Gas { get; set; }
        private double gas;

        public double Gas
        {
            get { return gas; }
            set
            {
                if (value >= 0)
                {
                    gas = value;
                }
            }
        }


        public bool IsEngineRunning { get; set; }
        public int Speed { get; set; }
        public string Direction { get; set; }

        public Car()
            : this(14.5)
        {

        }
        public Car(double tankCapacity)
        {
            Direction = "North";
            TankCapacity = tankCapacity;
            FillTank();
            carCount++;
            carNumber = carCount;
            LocationX = randomGenerator.Next(1, 78);
            LocationY = randomGenerator.Next(1, 21);
        }

        public void FillTank()
        {
            Gas = TankCapacity;
        }

        public void StartEngine()
        {
            if (Gas > 0)
            {
                IsEngineRunning = true;
            }
        }

        public void StopEngine()
        {
            IsEngineRunning = false;
            Speed = 0;
        }

        public void MakeRandomMovement()
        {
            switch (randomGenerator.Next(1, 7))
            {
                case 1:
                    TurnLeft();
                    break;
                case 2:
                    TurnRight();
                    break;
                default:
                    Accelerate();
                    break;

            }
        }
        public void Accelerate()
        {
            if (IsEngineRunning)
            {
                Speed++;
                switch (Direction)
                {
                    case "North":
                        LocationY--;
                        break;
                    case "South":
                        LocationY++;
                        break;
                    case "West":
                        LocationX--;
                        break;
                    case "East":
                        LocationX++;
                        break;
                }
                Gas--;
                if (Gas == 0)
                {
                    StopEngine();
                }
            }
        }

        public void Brake()
        {
            if (IsEngineRunning && (Speed > 0))
            {
                Speed--;
            }
        }

        public void TurnRight()
        {
            if (Direction == "North")
            {
                Direction = "East";
            }
            else if (Direction == "East")
            {
                Direction = "South";
            }
            else if (Direction == "South")
            {
                Direction = "West";
            }
            else
            {
                Direction = "North";
            }

        }

        public void TurnLeft()
        {
            if (Direction == "North")
            {
                Direction = "West";
            }
            else if (Direction == "East")
            {
                Direction = "North";
            }
            else if (Direction == "South")
            {
                Direction = "East";
            }
            else
            {
                Direction = "South";
            }

        }

        public void Display()
        {
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(LocationX, LocationY);
            Console.Write(carNumber);
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }
    }
}
