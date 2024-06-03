namespace Task3
{
    public interface ICommand
    {
        public short Repeat { get; set; }
        public void Execute();
    }
}
