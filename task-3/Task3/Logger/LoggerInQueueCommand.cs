using System.Text;

namespace Task3.Logger
{
    /// <summary>
    /// Команда ставящая в очередь команду, пишущую в лог.
    /// </summary>
    public class LoggerInQueueCommand : ICommand
    {
        private Exception exception;
        private Queue<ICommand> queue;
        private StringBuilder log;
        public LoggerInQueueCommand(Exception ex, Queue<ICommand> queue, StringBuilder log)
        {
            this.exception = ex;
            this.queue = queue;
            this.log = log;
        }
        public void Execute()
        {
            queue.Enqueue(new LoggerCommand(exception, log));
        }

        public short Repeat { get; set; } = 0;
    }
}
