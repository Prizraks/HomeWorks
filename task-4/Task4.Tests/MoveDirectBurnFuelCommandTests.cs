using Moq;

using System.Numerics;

using Task4.Interfaces;

namespace Task4.Tests
{
    public class MoveDirectBurnFuelCommandTests
    {
        private MoveDirectBurnFuelCommand Create(IMovable? movable = null, IFuelable? fuelable = null)
        {
            fuelable ??= new Mock<IFuelable>().Object;
            movable ??= new Mock<IMovable>().Object;

            return new MoveDirectBurnFuelCommand(movable, fuelable);
        }

        [Fact]
        public void Test1()
        {
            var movable = new Mock<IMovable>();
            movable
                .Setup(x => x.Position)
                .Returns(new Vector2(12, 5))
                .Verifiable();
            movable
                .Setup(x => x.Velocity)
                .Returns(new Vector2(-7, 3))
                .Verifiable();
            movable.SetupSet(x => x.Position = new Vector2(5, 8)).Verifiable();

            var fuelable = new Mock<IFuelable>();
            fuelable
                .Setup(x => x.Fuel)
                .Returns(50)
                .Verifiable();
            fuelable
                .Setup(x => x.FuelForStep)
                .Returns(10)
                .Verifiable();
            fuelable.SetupSet(x => x.Fuel = 40).Verifiable();

            var command = Create(movable.Object, fuelable.Object);

            var exception = Record.Exception(() => command.Execute());

            Assert.Null(exception);
        }
    }

}
