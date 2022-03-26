namespace FizzBuzzSample.Services.Contracts
{
    public interface IFizzBuzzService
    {
        Dictionary<string, List<string>> Process(string commaSeparatedValues);
    }
}
