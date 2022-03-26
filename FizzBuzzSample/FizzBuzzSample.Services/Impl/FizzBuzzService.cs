using FizzBuzzSample.Core.Helpers;
using FizzBuzzSample.Services.Contracts;

namespace FizzBuzzSample.Services.Impl
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private const string EmptyStringToken = "<empty>";
        private const string InvalidInput = "Invalid Item";        

        private readonly int[] divisors = new[] { 3, 5 };
        private readonly Dictionary<int,string> termsMap = new Dictionary<int, string> { { 3, "Fizz" }, { 5, "Buzz" }, { 8, "FizzBuzz"} };        

        public Dictionary<string, List<string>> Process(string commaSeparatedValues)
        {
            var output = new Dictionary<string, List<string>>();

            if (!IsValid(commaSeparatedValues))
            {
                output.Add(EmptyStringToken, new List<string> { InvalidInput });
                return output;
            }

            string[] inputFragments = commaSeparatedValues.Split(',');

            foreach (string inputFragment in inputFragments)
            {
                if (output.ContainsKey(inputFragment))
                {
                    continue;
                }

                if (!IsValid(inputFragment))
                {                    
                    output.TryAdd(EmptyStringToken, new List<string> { InvalidInput });
                    continue;
                }
                if (!int.TryParse(inputFragment, out int dividend))
                {
                    output.Add(inputFragment, new List<string> { InvalidInput });
                    continue;
                }               
                
                var divisibilityResult = CheckDivisibility(dividend);

                if (termsMap.TryGetValue(divisibilityResult.Item1, out string result))
                {
                    output.Add(inputFragment, new List<string> { result });
                }
                else
                {
                    output.Add(inputFragment, divisibilityResult.Item2);
                }
            }
            return output;            
        }

        private Tuple<int, List<string>> CheckDivisibility(int dividend)
        {
            int counter = 0;
            List<string> divisionLog = new();
            for (int i = 0; i < divisors.Length; i++)
            {
                int divisor = divisors[i];
                if (divisor == dividend)
                {
                    counter += divisor;
                    break;
                }
                else if (dividend.IsDivisibleBy(divisor))
                {
                    counter += divisor;
                }
                else
                {
                    divisionLog.Add($"Divided {dividend} by {divisor}");
                }
            }

            return new Tuple<int, List<string>>(counter, divisionLog);
        }

        private bool IsValid(string input) => !string.IsNullOrWhiteSpace(input);       

    }
}
