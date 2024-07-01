using HomeWorks.IocContainer.Interfaces;

namespace HomeWorks.IocContainer
{
    public class Scope : IScope
    {

        /// <summary>
        /// ключ и стратегия которая вынимает нам объект
        /// </summary>
        internal IDictionary<string, Func<object[], object>> Dependencies { get; set; }
        internal IScope Parent { get; set; }
        public Scope(IDictionary<string, Func<object[], object>> dependencies, IScope parent)
        {
            Dependencies = dependencies;
            Parent = parent;
        }

        public object Resolve(string key, object[] args)
        {
            return Dependencies.TryGetValue(key, out Func<object[], object>? dependencyResolver)
                ? dependencyResolver!(args)
                : Parent.Resolve(key, args); // Ищем в родительском скоупе, если не находим зависимости в текущем скоупе.
        }
    }
}
