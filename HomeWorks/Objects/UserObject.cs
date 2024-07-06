using System.Numerics;
using System.Reflection;
using UserObjects.Interfaces;

namespace UserObjects.Objects;

public class UserObject : IUserObject
{
    public virtual Vector2 Position { get; set; }
    public int Direction { get; set; }
    public int DirectionsNumber { get; set; }
    public virtual int Velocity { get; set; }
    public virtual int AngularVelocity { get; set; }

    public UserObject()
    {
        Position = Vector2.Zero;

        Direction = 0;
        DirectionsNumber = 8;
        Velocity = 0;
        AngularVelocity = 0;
    }

    public object GetProperty(string name)
    {
        PropertyInfo? propInfo = typeof(UserObject).GetProperty(name);
        if (propInfo is not null)
        {
            return propInfo.GetValue(this);
        }
        else
        {
            throw new KeyNotFoundException("Свойство не найдено");
        }
    }

    public void SetProperty(string name, object value)
    {
        var propInfo = typeof(UserObject).GetProperty(name);
        if (propInfo is not null)
        {
            propInfo.SetValue(this, value);
        }
        else
        {
            throw new KeyNotFoundException("Свойство не найдено");
        }

    }
}