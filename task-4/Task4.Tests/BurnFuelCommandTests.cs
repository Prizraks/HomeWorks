using Moq;
using Task4.Interfaces;

namespace Task4.Tests
{
    public class BurnFuelCommandTests
    {
        private BurnFuelCommand Create(IFuelable? fuelable = null)
        {
            if (fuelable is null)
            {
                var mock = new Mock<IFuelable>();
                mock.Setup(x => x.Fuel).Returns(100);
                mock.Setup(x => x.FuelForStep).Returns(10);
                fuelable = mock.Object;
            }

            return new BurnFuelCommand(fuelable);
        }

        [Theory]
        [InlineData(150, 20, 130)]
        [InlineData(130, -10, 140)]
        [InlineData(40, 80, -40)]
        public void Test1(int fuel, int fuelStep, int expected)
        {
            var mock = new Mock<IFuelable>();
            mock.Setup(x => x.Fuel).Returns(fuel);
            mock.Setup(x => x.FuelForStep).Returns(fuelStep);
            mock.SetupSet(x => x.Fuel = expected).Verifiable();

            var command = Create(mock.Object);
            command.Execute();
            mock.Verify();
        }
    }
}