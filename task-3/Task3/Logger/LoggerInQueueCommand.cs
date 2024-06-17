namespace Task3.Logger
{
    /// <summary>
    /// Команда ставящая в очередь команду, пишущую в лог.
    /// </summary>
    public class LoggerInQueueCommand : ICommand
    {
        private Exception exception;
        private Queue<ICommand> queue;
        public LoggerInQueueCommand(Exception ex, Queue<ICommand> queue)
        {
            this.exception = ex;
            this.queue = queue;
        }
        public void Execute()
        {
            queue.Enqueue(new LoggerCommand(exception));
        }

        public short Repeat { get; set; } = 0;
    }
}
