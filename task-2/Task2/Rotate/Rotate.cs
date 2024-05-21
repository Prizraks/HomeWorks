namespace Task2.Rotate
{
    public class Rotate
    {
        IRotable _rotable;
        public Rotate(IRotable rotable)
        {
            _rotable = rotable;
        }

        public void Execute()
        {
            _rotable.SetDirection(
                (_rotable.GetDirection() + _rotable.GetAngularVelocity()) % _rotable.GetDirectionsNumber()
            );
        }
    }
}
