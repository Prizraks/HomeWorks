namespace HomeWorks.IocContainer.Interfaces
{
    public interface IScope
    {
        object Resolve(string key, object[] args);
    }
}
