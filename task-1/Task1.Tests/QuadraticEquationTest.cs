namespace Task1.Tests
{
    using Task1.Exceptions;

    /// <summary>
    /// Тесты квадратичного уровнения.
    /// </summary>
    public class QuadraticEquationTest
    {
        [Fact]
        public void DiscriminantBelowZero()
        {
            var result = QuadraticEquation.Solve(a: 1, b: 0, c: 1);
            Assert.Empty(result);
        }

        [Fact]
        public void DiscriminantAboveZero()
        {
            var result = QuadraticEquation.Solve(a: 1, b: 3, c: 1);

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void DiscriminantEqualZero()
        {
            var result = QuadraticEquation.Solve(a: 1, b: 2, c: 1);

            Assert.Equal(result[0], result[1]);
        }

        [Fact]
        public void CoeffAEqualZero()
        {
            var act = () => QuadraticEquation.Solve(a: 0, b: 2, c: 1);

            Assert.Throws<CoeffAEqualZeroException>(act);
        }

        [Fact]
        public void CoeffNanNumber()
        {
            var act = () => QuadraticEquation.Solve(a: 1, b: Double.NaN, c: 1);

            Assert.Throws<CoeffNanNumberException>(act);
        }

        [Fact]
        public void CoeffInfinity()
        {
            var act = () => QuadraticEquation.Solve(a: Double.NegativeInfinity, b: 2, c: 1);

            Assert.Throws<CoeffNanNumberException>(act);
        }
    }
}