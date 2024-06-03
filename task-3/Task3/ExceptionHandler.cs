using Task3.Logger;

namespace Task3
{
    public class ExceptionHandler
    {
        private readonly IDictionary<Type, IDictionary<Type, Func<ICommand, Exception, ICommand>>> store =
            new Dictionary<Type, IDictionary<Type, Func<ICommand, Exception, ICommand>>>();

        public ICommand Handle(ICommand command, Exception ex)
        {
            var commandType = command.GetType();
            var exType = ex.GetType();

            return store[commandType][exType](command, ex);
        }

        public void RegisterHandler(Type comandType, Type exType, Func<ICommand, Exception, ICommand> func)
        {
            if (store.Count == 0 || !store.ContainsKey(comandType))
            {
                store.Add(comandType, new Dictionary<Type, Func<ICommand, Exception, ICommand>>());

                if (!store[comandType].ContainsKey(exType))
                {
                    store[comandType].Add(exType, func);
                }
            }

            store[comandType][exType] = func;
        }
    }
}
