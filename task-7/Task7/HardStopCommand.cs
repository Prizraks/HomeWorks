using Task7.Interfaces;

namespace Task7
{
    public class HardStopCommand : ICommand
    {
        private CommandQueue thread;

        public HardStopCommand(CommandQueue thread)
        {
            this.thread = thread;
        }

        public void Execute()
        {
            if (thread.thread != Thread.CurrentThread)
            {
                throw new Exception();
            }

            thread.canContinue = () => false;
        }
    }
}
