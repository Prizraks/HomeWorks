using HomeWorks.IocContainer.Interfaces;

namespace HomeWorks.IocContainer
{
    internal class LeafScope : IScope
    {
        private readonly object RootResolver;
        internal IDictionary<string, Func<object[], object>> Dependencies { get; set; }

        public LeafScope(Func<string, object[], object> func)
        {
            RootResolver = func;

        }
        public object Resolve(string key, object[] args)
        {
            return Dependencies?.TryGetValue(key, out Func<object[], object>? dependencyResolver) ?? false
                ? dependencyResolver!(args)
                : this;
        }
    }
}
