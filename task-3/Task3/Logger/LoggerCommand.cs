namespace Task3.Logger
{
    /// <summary>
    /// п.4 Команда, которая записывает информацию о выброшенном исключении в лог
    /// </summary>
    public class LoggerCommand : ICommand
    {
        private Exception exception;
        public LoggerCommand(Exception ex)
        {
            this.exception = ex;
        }
        public void Execute()
        {
            Console.Write(exception.Message);
        }

        public short Repeat { get; set; } = 0;
    }
}
