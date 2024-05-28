namespace Task2.Move
{
    public class Move(IMovable movable)
    {
        private IMovable _movable = movable;

        public void Execute()
        {
            _movable.SetPosition(_movable.GetPosition() + _movable.GetVelocity());
        }
    }
}
