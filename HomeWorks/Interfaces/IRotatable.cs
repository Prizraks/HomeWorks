namespace UserObjects.Interfaces;

public interface IRotatable
{
    int GetDirection();
    int GetAngularVelocity();
    void SetDirection(int newValue);
    int GetDirectionsNumber();
}
