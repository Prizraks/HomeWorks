using Moq;

using Task4.Exceptions;
using Task4.Interfaces;

namespace Task4.Tests
{
    public class MacroCommandTests
    {
        private MacroCommand Create(ICommand[]? commands = null)
        {
            commands ??=
            [
                new MoveCommand(new Mock<IMovable>().Object),
                new RotateCommand(new Mock<IRotable>().Object)
            ];

            return new MacroCommand(commands);
        }

        [Fact]
        public void Test1()
        {
            var checkFieldCommand = new Mock<ICommand>();
            checkFieldCommand.Setup(x => x.Execute()).Verifiable();

            var moveCommand = new Mock<ICommand>();
            moveCommand.Setup(x => x.Execute()).Verifiable();

            var burnFuelCommand = new Mock<ICommand>();
            burnFuelCommand.Setup(x => x.Execute()).Verifiable();

            MacroCommand macro = Create([checkFieldCommand.Object, moveCommand.Object, burnFuelCommand.Object]);
            macro.Execute();

            checkFieldCommand.Verify(x => x.Execute(), Times.Once);
            moveCommand.Verify(x => x.Execute(), Times.Once);
            burnFuelCommand.Verify(x => x.Execute(), Times.Once);
        }

        [Fact]
        public void Test2()
        {
            var command1 = new Mock<ICommand>();
            command1.Setup(x => x.Execute()).Verifiable();

            var command2 = new Mock<ICommand>();
            command2.Setup(x => x.Execute()).Throws(new CommandException());

            var command3 = new Mock<ICommand>();
            command3.Setup(x => x.Execute()).Verifiable();

            var macroCommand = new MacroCommand(command1.Object, command2.Object, command3.Object);

            Assert.Throws<CommandException>(() => macroCommand.Execute());

            command1.Verify(x => x.Execute(), Times.Once);
            command2.Verify(x => x.Execute(), Times.Once);
            command3.Verify(x => x.Execute(), Times.Never);
        }
    }
}
