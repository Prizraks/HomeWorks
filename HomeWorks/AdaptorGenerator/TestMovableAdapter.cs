using System.Numerics;

using UserObjects.Interfaces;
using UserObjects.Objects;

using HomeWorks.IocContainer;
using HomeWorks.Interfaces;

namespace HomeWorks.AdaptorGenerator
{
    internal class TestMovableAdapter(UserObject obj) : IMovable
    {
        UserObject obj = obj;

        public Vector2 GetPosition()
        {
            return IoC.Resolve<Vector2>("Spaceship.Operations.IMovable:position.get", obj);
        }

        public Vector2 GetVelocity()
        {
            return IoC.Resolve<Vector2>("Spaceship.Operations.IMovable:velocity.get", obj);
        }

        public void SetPosition(Vector2 newValue)
        {
            IoC.Resolve<ICommand>("Spaceship.Operations.IMovable:position.set", obj, newValue).Execute();
        }
    }
}
