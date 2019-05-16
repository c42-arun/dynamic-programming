namespace DynamicProgramming.Fibonacci.FibonacciSeries
{
    public class Fibonacci_BruteForce_Recursion
    {
        public int CalculateFibonacci(int n)
        {
            if (n < 2)
            {
                return n;
            }

            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }
    }
}
