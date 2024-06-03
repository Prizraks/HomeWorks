namespace Task3.Repeaters
{
    public class RepeaterCommand : ICommand
    {
        private ICommand command;
        public short Repeat { get; set; } = 0;
        private Exception ex;
        public RepeaterCommand(ICommand command, Exception ex)
        {
            this.command = command;
            this.ex = ex;
        }
        public void Execute()
        {
            if (command.Repeat == 0)
            {
                command.Repeat = 1;
                command.Execute();
            }
            else
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
