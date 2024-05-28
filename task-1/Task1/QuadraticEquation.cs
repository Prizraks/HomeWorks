namespace Task1
{
    using Task1.Exceptions;

    public static class QuadraticEquation
    {
        public static double[] Solve(double a, double b, double c)
        {
            if (double.IsNaN(a) ||
                double.IsNaN(b) ||
                double.IsNaN(c) ||
                double.IsInfinity(a) ||
                double.IsInfinity(b) ||
                double.IsInfinity(c))
            {
                throw new CoeffNanNumberException("Коэффициенты 'а'/'b'/'c' должен быть не равен Nan или +/- Infinity");
            }

            if (Math.Abs(a) <= Double.Epsilon)
            {
                throw new CoeffAEqualZeroException("Коэффициент 'а' должен быть не равен 0");
            }

            var discriminant = Math.Pow(b, 2) - 4*a*c;
            if (discriminant > Double.Epsilon)
            {
                return [-b + Math.Sqrt(discriminant)/2*a,
                        -b - Math.Sqrt(discriminant)/2*a];
            }

            if (discriminant < -Double.Epsilon)
            {
                return [];
            }

            if (Math.Abs(discriminant) <= Double.Epsilon)
            {
                return [-b/2*a, -b/2*a];
            }

            return [];
        }
    }
}
