using Task4.Interfaces;

namespace Task4
{
    public class BurnFuelCommand : ICommand
    {
        private readonly IFuelable fuelable;
        public BurnFuelCommand(IFuelable fuelable)
        {
            this.fuelable = fuelable;
        }
        public void Execute()
        {
            fuelable.Fuel -= fuelable.FuelForStep;
        }
    }
}
