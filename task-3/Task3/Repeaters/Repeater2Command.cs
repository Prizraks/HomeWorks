namespace Task3.Repeaters
{
    public class Repeater2Command : ICommand
    {
        private ICommand command;
        private Queue<ICommand> queue;
        public short Repeat { get; set; } = 0;
        private Exception ex;
        public Repeater2Command(ICommand command, Exception ex, Queue<ICommand> queue)
        {
            this.command = command;
            this.queue = queue;
            this.ex = ex;
        }
        public void Execute()
        {
            if (command.Repeat < 2)
            {
                command.Repeat++;
                queue.Enqueue(command);
            }
            else
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
