using Task4.Exceptions;
using Task4.Interfaces;

namespace Task4
{
    public class CheckFuelCommand : ICommand
    {
        private readonly IFuelable checkableFuel;
        public CheckFuelCommand(IFuelable checkableFuel)
        {
            this.checkableFuel = checkableFuel;
        }
        public void Execute()
        {
            if ((checkableFuel.Fuel - checkableFuel.FuelForStep) < 0)
            {
                throw new CommandException("Для движения недостаточно топлива.");
            }
        }
    }

}
