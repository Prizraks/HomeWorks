using System.Collections.Concurrent;
using Task7.Interfaces;

namespace Task7
{
    public class CommandQueue
    {
        internal Func<bool> canContinue = () => true;
        internal Thread thread;
        internal BlockingCollection<ICommand> queue = new BlockingCollection<ICommand>(20);

        public CommandQueue()
        {
            thread = new Thread(ExecInSeparateThread);
            thread.Start();
        }

        public void Put(ICommand cmd)
        {
            queue.Add(cmd);
        }

        private void ExecInSeparateThread()
        {
            while (canContinue())
            {
                var cmd = queue.Take();

                try
                {
                    cmd.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Wait()
        {
            thread.Join();
        }
    }
}
