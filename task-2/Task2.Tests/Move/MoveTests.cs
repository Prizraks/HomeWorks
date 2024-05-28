namespace Task2.Tests.Move
{
    using Moq;
    using System.ComponentModel;
    using System.Numerics;
    using Task2.Move;

    public class MoveTests
    {
        [Fact]
        [DisplayName("Движение меняет положение объекта на (5, 8)")]
        public void Test1()
        {
            var movable = new Mock<IMovable>();
            movable
                .Setup(x => x.GetPosition())
                .Returns(new Vector2(12, 5))
                .Verifiable();
            movable
                .Setup(x => x.GetVelocity())
                .Returns(new Vector2(-7, 3))
                .Verifiable();

            var move = new Move(movable.Object);
            move.Execute();

            movable.Verify(x => x.SetPosition(new Vector2(5, 8)));
        }

        [Fact]
        [DisplayName("Невозможно прочитать положение в пространстве")]
        public void Test2()
        {
            var movable = new Mock<IMovable>();
            movable
                .Setup(x => x.GetPosition())
                .Throws(new InvalidOperationException("невозможно прочитать положение в пространстве"))
                .Verifiable();
            movable
                .Setup(x => x.GetVelocity())
                .Returns(new Vector2(-7, 3))
                .Verifiable();

            var move = new Move(movable.Object);

            Assert.Throws<InvalidOperationException>(() => move.Execute());
        }

        [Fact]
        [DisplayName("Невозможно прочитать значение мгновенной скорости")]
        public void Test3()
        {
            var movable = new Mock<IMovable>();
            movable
                .Setup(x => x.GetPosition())
                .Returns(new Vector2(12, 5))
                .Verifiable();
            movable
                .Setup(x => x.GetVelocity())
                .Throws(new InvalidOperationException("невозможно прочитать значение мгновенной скорости"))
                .Verifiable();

            var move = new Move(movable.Object);

            Assert.Throws<InvalidOperationException>(() => move.Execute());
        }

        [Fact]
        [DisplayName("Невозможно изменить положение в пространстве")]
        public void Test4()
        {
            var movable = new Mock<IMovable>();
            movable
                .Setup(x => x.GetPosition())
                .Returns(new Vector2(12, 5))
                .Verifiable();
            movable
                .Setup(x => x.GetVelocity())
                .Returns(new Vector2(-7, 3))
                .Verifiable();
            movable
                .Setup(x => x.SetPosition(new Vector2(5, 8)))
                .Throws(new InvalidOperationException("невозможно изменить положение в пространстве"))
                .Verifiable();

            var move = new Move(movable.Object);

            Assert.Throws<InvalidOperationException>(() => move.Execute());
        }
    }
}