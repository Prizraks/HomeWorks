using System.Numerics;

namespace Task2.Move
{
    public interface IMovable
    {
        Vector2 GetPosition();
        Vector2 GetVelocity();
        void SetPosition(Vector2 newValue);
    }
}
