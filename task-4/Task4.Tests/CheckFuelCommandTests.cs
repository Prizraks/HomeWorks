using Moq;

using Task4.Exceptions;
using Task4.Interfaces;

namespace Task4.Tests
{
    public class CheckFuelCommandTests
    {
        private static CheckFuelCommand Create(IFuelable? fuelable = null)
        {
            if (fuelable is null)
            {
                var mock = new Mock<IFuelable>();

                mock.Setup(x => x.Fuel).Returns(100);
                mock.Setup(x => x.FuelForStep).Returns(10);

                fuelable = mock.Object;
            }

            return new CheckFuelCommand(fuelable);
        }

        [Theory]
        [InlineData(90, 90)]
        [InlineData(50, 15)]
        public void Test1(int fuel, int fuelStep)
        {
            var mock = new Mock<IFuelable>();

            mock.Setup(x => x.Fuel).Returns(fuel);
            mock.Setup(x => x.FuelForStep).Returns(fuelStep);

            var check = Create(mock.Object);
            var exception = Record.Exception(() => check?.Execute());

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(90, 99)]
        [InlineData(5, 6)]
        public void Test2(int fuel, int fuelStep)
        {
            var mock = new Mock<IFuelable>();

            mock.Setup(x => x.Fuel).Returns(fuel);
            mock.Setup(x => x.FuelForStep).Returns(fuelStep);

            Assert.Throws<CommandException>(() => Create(mock.Object).Execute());
        }

    }
}
