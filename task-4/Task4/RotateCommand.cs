using Task4.Interfaces;

namespace Task4
{
    public class RotateCommand : ICommand
    {
        public readonly IRotable rotable;
        public RotateCommand(IRotable rotable)
        {
            this.rotable = rotable;
        }
        public virtual void Execute()
        {
            rotable.Direction = Math.Abs((rotable.Direction + rotable.AngularVelocity) % rotable.MaxDirections);
        }
    }

}
