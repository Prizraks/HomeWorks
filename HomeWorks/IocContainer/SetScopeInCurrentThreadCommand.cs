using HomeWorks.Interfaces;

namespace HomeWorks.IocContainer
{
    internal class SetScopeInCurrentThreadCommand : ICommand
    {
        private readonly Scope scope;
        public SetScopeInCurrentThreadCommand(Scope scope)
        {
            this.scope = scope;
        }

        public void Execute()
        {
            ScopeBasedResolveDependencyStrategy.CurrentScopes.Value = scope;

        }
    }
}
