using Task7.Interfaces;

namespace Task7.Tests
{
    public class ScalingTest
    {
        [Fact]
        // В случае HardStop команды, добавленные после нее команды не вызываются.
        public void IfHardStopInvoke()
        {
            ManualResetEvent manualResetEvent = new(false);
            var thread = new CommandQueue();

            var hardStopCommand = new WrapperCommand(
                new HardStopCommand(thread),
                () => manualResetEvent.WaitOne());
            thread.Put(hardStopCommand);
            var emptyCommand = new EmptyCommand();
            thread.Put(emptyCommand);

            manualResetEvent.Set();
            thread.Wait();

            Assert.False(emptyCommand.WasCalled);
        }

        [Fact]
        // В случае SoftStop команды добавленные после нее команды вызываются и цикл  останавливается только после выполнения всех команд.
        public void IfSoftStopInvoke()
        {
            ManualResetEvent manualResetEvent = new(false);
            var thread = new CommandQueue();

            var softStopCommand = new WrapperCommand(
                new SoftStopCommand(thread),
                () => manualResetEvent.WaitOne());
            thread.Put(softStopCommand);
            var emptyCommand = new EmptyCommand();
            thread.Put(emptyCommand);

            manualResetEvent.Set();
            thread.Wait();

            Assert.True(emptyCommand.WasCalled);
        }
    }

    public class EmptyCommand : ICommand
    {
        public bool WasCalled { get; set; }

        public EmptyCommand()
        {
            WasCalled = false;
        }
        public void Execute()
        {
            WasCalled = true;
        }
    }

    public class WrapperCommand : ICommand
    {
        ICommand internalCommand;
        Action beforeAction;

        public WrapperCommand(ICommand command, Action beforeAction)
        {
            this.beforeAction = beforeAction;
            this.internalCommand = command;
        }

        public void Execute()
        {
            beforeAction();
            internalCommand.Execute();
        }
    }
}