using System;
using Xunit;
using Derby;

namespace DerbyTest
{
    public class CarTest
    {
        [Fact]
        public void StartEngineTest()
        {
            Car c = new Car(15.0);
            c.StartEngine();
            Assert.True(c.IsEngineRunning);
        }

        [Fact]
        public void StartEngineEmptyTest()
        {
            Car c = new Car(0.0);
            c.StartEngine();
            Assert.False(c.IsEngineRunning);

        }

        [Fact]
        public void OnCreatetankCapacitytest()
        {
            Car c = new Car(15.0);
            Assert.Equal(15.0, c.TankCapacity);
        }

        [Fact]
        public void OnCreateGastest()
        {
            Car c = new Car(15.0);
            Assert.Equal(c.TankCapacity, c.Gas);
        }

    }
}
