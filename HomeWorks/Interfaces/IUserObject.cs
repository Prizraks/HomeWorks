namespace UserObjects.Interfaces;

public interface IUserObject
{
    object GetProperty(string name);
    void SetProperty(string name, object value);
}
