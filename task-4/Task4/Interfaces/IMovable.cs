using System.Numerics;

namespace Task4.Interfaces
{
    public interface IMovable
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; }
    }

}
