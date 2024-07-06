using System.Numerics;

namespace UserObjects.Interfaces;

public interface IMovable
{
    Vector2 GetPosition();
    Vector2 GetVelocity();
    void SetPosition(Vector2 newValue);
}
