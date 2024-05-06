namespace Task1.Exceptions
{
    using System;

    public class CoeffNanNumberException : Exception
    {
        public CoeffNanNumberException()
        {
        }

        public CoeffNanNumberException(string message)
            : base(message)
        {
        }

        public CoeffNanNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
