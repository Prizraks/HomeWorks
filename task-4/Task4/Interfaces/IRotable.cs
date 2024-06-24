namespace Task4.Interfaces
{
    public interface IRotable
    {
        int Direction { get; set; }
        int AngularVelocity { get; }
        int MaxDirections { get; }
    }

}
