using System.Text;

namespace Task3.Logger
{
    /// <summary>
    /// п.4 Команда, которая записывает информацию о выброшенном исключении в лог
    /// </summary>
    public class LoggerCommand : ICommand
    {
        private Exception exception;
        private StringBuilder log;
        public LoggerCommand(Exception ex, StringBuilder log)
        {
            this.exception = ex;
            this.log = log;
        }
        public void Execute()
        {
            //Console.Write(exception.Message);
            log.Append(exception.Message);
        }

        public short Repeat { get; set; } = 0;
    }
}
