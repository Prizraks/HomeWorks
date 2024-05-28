namespace Task1.Exceptions
{
    using System;

    public class CoeffAEqualZeroException : Exception
    {
        public CoeffAEqualZeroException()
        {
        }

        public CoeffAEqualZeroException(string message)
            : base(message)
        {
        }

        public CoeffAEqualZeroException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
