using HomeWorks.Interfaces;

namespace HomeWorks.IocContainer
{
    internal class InitSingleThreadScopeCommand : ICommand
    {
        public void Execute()
        {
            IoC.Resolve<ICommand>(
               "Ioc.Register",
               "Scopes.Storage",
               (Func<object[], object>)((args) => new Dictionary<string, Func<object[], object>>())
               ).Execute();
        }
    }
}
