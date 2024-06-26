using Task7.Interfaces;

namespace Task7
{
    public class SoftStopCommand : ICommand
    {
        private CommandQueue thread;

        public SoftStopCommand(CommandQueue thread)
        {
            this.thread = thread;
        }

        public void Execute()
        {
            if (Thread.CurrentThread != thread.thread)
            {
                throw new Exception();
            }

            thread.canContinue = () => thread.queue.Count() > 0;
        }
    }
}
