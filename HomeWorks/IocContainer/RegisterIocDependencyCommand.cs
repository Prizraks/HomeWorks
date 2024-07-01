using HomeWorks.Interfaces;

namespace HomeWorks.IocContainer
{
    internal class RegisterIocDependencyCommand : ICommand
    {
        private readonly string key;
        private readonly Func<object[], object> strategy;
        public RegisterIocDependencyCommand(string key, Func<object[], object> strategy)
        {
            this.key = key;
            this.strategy = strategy;
        }

        public void Execute()
        {
            if (!ScopeBasedResolveDependencyStrategy.CurrentScopes.Value!.Dependencies.TryAdd(key, strategy))
            {
                throw new Exception("Не получилось зарегистрировать зависимость");
            }
        }
    }
}
