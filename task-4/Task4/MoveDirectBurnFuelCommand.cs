using Task4.Interfaces;

namespace Task4
{
    public class MoveDirectBurnFuelCommand : MacroCommand
    {
        public MoveDirectBurnFuelCommand(IMovable movable, IFuelable fuelable)
        {
            commands =
            [
                new CheckFuelCommand(fuelable),
                new MoveCommand(movable),
                new BurnFuelCommand(fuelable)
            ];
        }
    }
}