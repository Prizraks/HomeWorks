namespace Task2.Rotate
{
    public interface IRotable
    {
        int GetDirection();
        int GetAngularVelocity();
        void SetDirection(int newValue);
        int GetDirectionsNumber();

    }
}
