namespace Task3.Rotate
{
    public class RotateCommand : ICommand
    {
        public short Repeat { get; set; } = 0;
        public void Execute()
        {
            if (Repeat == 1)
            {
                throw new RepeaterException("Повторная ошибка RotateCommand");
            }
            else
            {
                throw new Exception("Ошибка RotateCommand");
            }
        }
    }
}
