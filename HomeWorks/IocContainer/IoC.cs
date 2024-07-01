namespace HomeWorks.IocContainer
{
    public class IoC
    {
        internal static Func<string, object[], object> Strategy { get; set; } = DefaultStrategy;

        public static T Resolve<T>(string key, params object[] args)
        {
            return (T)Strategy(key, args);
        }

        /// <summary>
        /// Можно гибко адаптировать то, как мы реализуем наш IOC.
        /// Можно обернуть в эту сигнатуру уже готовый IOC.
        /// Можно сделать однопоточным или многопоточным.
        /// Дефолтная стратегия она одноразовая
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="args">Параметры.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static object DefaultStrategy(string key, object[] args)
        {
            if ("IoC.SetupStrategy" == key)
            {
                // Заменяем стратегию по дефолту.
                return new SetupStrategyCommand((Func<string, object[], object>)args[0]);
            }
            else if ("IoC.Default" == key)
            {
                return (object)DefaultStrategy;
            }
            else
            {
                throw new ArgumentException($"Зависимость IoC с ключом {key} не найдена. Вы уверены, что эта зависимость существует?");
            }
        }
    }
}
