namespace Task3.Move
{
    public class MoveCommand : ICommand
    {
        public short Repeat { get; set; } = 0;
        public void Execute()
        {
            if (Repeat == 2)
            {
                throw new RepeaterException("3-я ошибка MoveCommand");
            }
            else
            {
                throw new Exception("Ошибка RotateCommand");
            }
        }
    }
}
