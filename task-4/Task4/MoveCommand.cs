using Task4.Interfaces;

namespace Task4
{
    public class MoveCommand : ICommand
    {
        private readonly IMovable movable;
        public MoveCommand(IMovable movable)
        {
            this.movable = movable;
        }

        public void Execute()
        {
            if (movable == null || movable.Position == null || movable.Velocity == null)
            {
                throw new ArgumentException(nameof(movable));
            }

            movable.Position += movable.Velocity;
        }
    }

}
