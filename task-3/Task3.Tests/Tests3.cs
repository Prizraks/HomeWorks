namespace Task3.Tests
{
    using Task3.Logger;
    using Task3.Move;
    using Task3.Repeaters;
    using Task3.Rotate;

    public class Tests3
    {
        [Fact]
        ///Реализовать Команду, которая записывает информацию о выброшенном исключении в лог.
        public void Test4()
        {
            //Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var rotateCommand = new RotateCommand();
            var exHandler = new ExceptionHandler();
            exHandler.RegisterHandler(
                typeof(RotateCommand),
                typeof(Exception),
                (a, b) => new LoggerCommand(b));

            try
            {
                rotateCommand.Execute();
            }
            catch (Exception e)
            {
                exHandler.Handle(rotateCommand, e).Execute();
            }
            Assert.Equal("Ошибка RotateCommand\n", stringWriter.ToString());
        }

        [Fact]
        ///Реализовать обработчик исключения, который ставит Команду, пишущую в лог в очередь Команд
        public void Test5()
        {
            //Act
            var rotateCommand = new RotateCommand();
            var queue = new Queue<ICommand>();
            var exHandler = new ExceptionHandler();
            exHandler.RegisterHandler(
                typeof(RotateCommand),
                typeof(Exception),
                (a, b) => new LoggerInQueueCommand(b, queue));

            try
            {
                rotateCommand.Execute();
            }
            catch (Exception e)
            {
                exHandler.Handle(rotateCommand, e).Execute();
            }

            Assert.Single(queue);
        }

        [Fact]
        ///Реализовать Команду, которая повторяет Команду, выбросившую исключение.
        public void Test6()
        {
            ///Act
            var rotateCommand = new RotateCommand();
            var queue = new Queue<ICommand>();
            var exHandler = new ExceptionHandler();
            exHandler.RegisterHandler(
                    typeof(RotateCommand),
                    typeof(Exception),
                    (a, b) => new RepeaterCommand(a, b));

            try
            {
                rotateCommand.Execute();
            }
            catch (Exception e)
            {
                Assert.Throws<RepeaterException>(() => exHandler.Handle(rotateCommand, e).Execute());
            }
        }

        [Fact]
        ///Реализовать обработчик исключения, который ставит в очередь Команду - повторитель команды, выбросившей исключение.
        public void Test7()
        {
            //Act
            var rotateCommand = new RotateCommand();
            var queue = new Queue<ICommand>();
            var exHandler = new ExceptionHandler();
            exHandler.RegisterHandler(
                typeof(RotateCommand),
                typeof(Exception),
                (a, b) => new RepeaterInQueueCommand(a, b, queue));

            try
            {
                rotateCommand.Execute();
            }
            catch (Exception e)
            {
                exHandler.Handle(rotateCommand, e).Execute();
            }

            Assert.Single(queue);
        }

        [Fact]
        ///При первом выбросе исключения повторить команду, при повторном выбросе исключения записать информацию в лог.
        public void Test8()
        {
            //Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var rotateCommand = new RotateCommand();
            var queue = new Queue<ICommand>();
            queue.Enqueue(rotateCommand);

            var exHandler = new ExceptionHandler();
            exHandler.RegisterHandler(
                typeof(RotateCommand),
                typeof(Exception),
                (a, b) => new RepeaterInQueueCommand(a, b, queue));
            exHandler.RegisterHandler(
                typeof(RotateCommand),
                typeof(RepeaterException),
                (a, b) => new LoggerCommand(b));

            while (queue.Count != 0)
            {
                try
                {
                    queue.Dequeue().Execute();
                }
                catch (Exception e)
                {
                    exHandler.Handle(rotateCommand, e).Execute();
                }
            }

            Assert.Equal("Повторная ошибка RotateCommand\n", stringWriter.ToString());
        }

        [Fact]
        ///повторить два раза, потом записать в лог.
        public void Test9()
        {
            //Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var moveCommand = new MoveCommand();
            var queue = new Queue<ICommand>();
            queue.Enqueue(moveCommand);

            var exHandler = new ExceptionHandler();
            exHandler.RegisterHandler(
                typeof(MoveCommand),
                typeof(Exception),
                (a, b) => new Repeater2Command(a, b, queue));
            exHandler.RegisterHandler(
                typeof(MoveCommand),
                typeof(RepeaterException),
                (a, b) => new LoggerCommand(b));

            while (queue.Count != 0)
            {
                try
                {
                    queue.Dequeue().Execute();
                }
                catch (Exception e)
                {
                    exHandler.Handle(moveCommand, e).Execute();
                }
            }

            Assert.Equal("3-я ошибка MoveCommand\n", stringWriter.ToString());
        }
    }
}