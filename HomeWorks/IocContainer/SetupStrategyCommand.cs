using HomeWorks.Interfaces;

namespace HomeWorks.IocContainer
{
    internal class SetupStrategyCommand : ICommand
    {
        private readonly Func<string, object[], object> newStrategy;
        public SetupStrategyCommand(Func<string, object[], object> newStrategy)
        {
            this.newStrategy = newStrategy;
        }

        /// <summary>
        /// Заменает стандартную команду.
        /// </summary>
        public void Execute()
        {
            IoC.Strategy = newStrategy;
        }
    }
}
