namespace Task2.Tests.Rotate
{
    using Moq;
    using System.ComponentModel;
    using Task2.Rotate;

    public class RotateTests
    {
        [Fact]
        [DisplayName("Происходит поворот с 200 градусов на 20 градусов(отсчет с 0-го положения), угловая скорость 180 градусов")]
        public void Test1()
        {
            var rotable = new Mock<IRotable>();
            rotable
                .Setup(x => x.GetDirection())
                .Returns(200)
                .Verifiable();
            rotable
                .Setup(x => x.GetAngularVelocity())
                .Returns(180)
                .Verifiable();
            rotable
                .Setup(x => x.GetDirectionsNumber())
                .Returns(360)
                .Verifiable();

            var rotate = new Rotate(rotable.Object);
            rotate.Execute();

            rotable.Verify(x => x.SetDirection(20));
        }

        [Fact]
        [DisplayName("Невозможно прочитать угловую скорость")]
        public void Test2()
        {
            var rotable = new Mock<IRotable>();
            rotable
                .Setup(x => x.GetDirection())
                .Returns(180)
                .Verifiable();
            rotable
                .Setup(x => x.GetAngularVelocity())
                .Throws(new InvalidOperationException("невозможно прочитать угловую скорость"))
                .Verifiable();
            rotable
                .Setup(x => x.GetDirectionsNumber())
                .Returns(360)
                .Verifiable();

            var rotate = new Rotate(rotable.Object);

            Assert.Throws<InvalidOperationException>(() => rotate.Execute());
        }
    }
}