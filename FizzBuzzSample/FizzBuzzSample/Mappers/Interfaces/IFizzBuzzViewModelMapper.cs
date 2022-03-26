using FizzBuzzSample.Core.Interfaces;
using FizzBuzzSample.Models;

namespace FizzBuzzSample.Mappers.Interfaces
{
    public interface IFizzBuzzViewModelMapper : IMap<FizzBuzzViewModel, KeyValuePair<string, List<string>>>, IMap<List<FizzBuzzViewModel>, Dictionary<string, List<string>>>
    {

    }
}
