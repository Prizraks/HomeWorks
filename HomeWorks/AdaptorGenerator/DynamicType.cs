namespace HomeWorks.AdaptorGenerator
{
    public class DynamicType
    {
        private int number1;

        public DynamicType() : this(42) 
        {
        }
        public DynamicType(int initNumber)
        {
            number1 = initNumber;
        }

        public int Number
        {
            get { return number1; }
            set { number1 = value; }
        }

        public int MyMethod(int multiplier)
        {
            return number1 * multiplier;
        }
    }
}
