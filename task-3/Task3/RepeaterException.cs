namespace Task3
{
    /// <summary>
    /// Ошибка повтора.
    /// </summary>
    public class RepeaterException : Exception
    {
        public RepeaterException()
        {
        }

        public RepeaterException(string message)
            : base(message)
        {
        }

        public RepeaterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
