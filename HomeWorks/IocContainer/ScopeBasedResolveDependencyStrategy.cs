namespace HomeWorks.IocContainer
{
    internal class ScopeBasedResolveDependencyStrategy
    {
        internal static Scope? Root { get; set; }
        internal static Func<object> DefaultScope = () => Root!;
        internal static ThreadLocal<Scope> CurrentScopes { get; private set; } = new ThreadLocal<Scope>();
        public static object Resolve(string key, object[] args)
        {
            if (key == "Scopes.Root")
            {
                return Root!;
            }
            else
            {
                var scope = CurrentScopes.Value;

                scope ??= (Scope)DefaultScope();

                return scope!.Resolve(key, args);
            }
        }

    }
}

