using Task4.Interfaces;

namespace Task4
{
    public class MacroCommand : ICommand
    {
        protected ICommand[] commands;
        public MacroCommand(params ICommand[] commands)
        {
            this.commands = commands;
        }
        public void Execute()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }
    }

}
