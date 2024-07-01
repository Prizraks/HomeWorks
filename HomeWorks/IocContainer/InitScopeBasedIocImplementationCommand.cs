using System.Collections.Concurrent;
using HomeWorks.Interfaces;

namespace HomeWorks.IocContainer
{

    public class InitScopeBasedIocImplementationCommand : ICommand
    {
        /// <summary>
        /// Инициализация IOC на базе иерархических скоупов
        /// </summary>
        public void Execute()
        {
            if (ScopeBasedResolveDependencyStrategy.Root is not null)
            {
                return;
            }

            // Словарь зависимостей.
            var dependencies = new ConcurrentDictionary<string, Func<object[], object>>();

            //Рутовый скоуп - стратегия.
            var scope = new Scope(
                dependencies,
                new LeafScope(IoC.Resolve<Func<string, object[], object>>("IoC.Default"))
                );

            //Хранилище скоупов - словарь скоупов.
            dependencies.TryAdd("Scopes.Storage", (args) =>
            {
                return new ConcurrentDictionary<string, Func<object[], object>>();
            });

            //Операция создания нового скоупа.
            dependencies.TryAdd("Scopes.NewScope", (args) =>
            {
                return new Scope(
                    IoC.Resolve<IDictionary<string, Func<object[], object>>>("Scopes.Storage"),
                    (Scope)args[0]);
            });

            // Получить доступ к текущему скоупу.
            dependencies.TryAdd("Scopes.Current", (args) =>
            {
                var scope = ScopeBasedResolveDependencyStrategy.CurrentScopes.Value;
                if (scope != null)
                {
                    return scope;
                }
                else
                {
                    return ScopeBasedResolveDependencyStrategy.DefaultScope;
                }
            });

            //Установить в текущем потоке нужный нам скоуп.
            dependencies.TryAdd("Scope.Current.Set", (args) =>
            {
                return new SetScopeInCurrentThreadCommand((Scope)args[0]);
            });

            //Команда, которая регистрирует новые зависимости.
            dependencies.TryAdd("IoC.Register", (args) =>
            {
                return new RegisterIocDependencyCommand((string)args[0], (Func<object[], object>)args[1]);
            });

            ScopeBasedResolveDependencyStrategy.Root = scope;

            // Базовая стратегия, которую мы собрали регистрируется в IOC контейнере.
            IoC.Resolve<ICommand>("IoC.SetupStrategy", (object)ScopeBasedResolveDependencyStrategy.Resolve).Execute();
            new SetScopeInCurrentThreadCommand(scope).Execute();

        }
    }
}
