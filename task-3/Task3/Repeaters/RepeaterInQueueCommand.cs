namespace Task3.Repeaters
{
    /// <summary>
    /// Команда ставящая в очередь команду, пишущую в лог.
    /// </summary>
    public class RepeaterInQueueCommand : ICommand
    {
        private ICommand command;
        private Queue<ICommand> queue;
        public short Repeat { get; set; } = 0;
        private Exception ex;
        public RepeaterInQueueCommand(ICommand command, Exception ex, Queue<ICommand> queue)
        {
            this.command = command;
            this.queue = queue;
            this.ex = ex;
        }
        public void Execute()
        {
            if(command.Repeat == 0) 
            {
                command.Repeat = 1;
                queue.Enqueue(command);
            } 
            else
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
