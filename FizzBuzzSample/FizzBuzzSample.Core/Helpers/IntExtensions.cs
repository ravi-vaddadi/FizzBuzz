namespace FizzBuzzSample.Core.Helpers
{
    public static class IntExtensions
    {
        public static bool IsDivisibleBy(this int dividend, int divisor)
        {
            return dividend % divisor == 0;
        }
    }
}
