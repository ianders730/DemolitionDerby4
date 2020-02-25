using System;
using System.Collections.Generic;
using System.Text;

namespace Derby
{
    public class Car
    {
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
            : this(15)
        {

        }
        public Car(double tankCapacity)
        {
            Direction = "North";
            TankCapacity = tankCapacity;
            FillTank();
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
                Console.WriteLine($"Engine Started!");

            }
        }

        public void StopEngine()
        {
            IsEngineRunning = false;
            Speed = 0;
            Console.WriteLine("Engine Stopped.");
        }

        public void Accelerate()
        {
            if (IsEngineRunning)
            {
                Speed++;
                Console.WriteLine("Vroom!!");
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
                Console.WriteLine("Screech!");
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

    }
}
