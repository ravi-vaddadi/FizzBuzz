using FizzBuzzSample.Mappers.Interfaces;
using FizzBuzzSample.Models;

namespace FizzBuzzSample.Mappers.Impl
{

    public class FizzBuzzViewModelMapper : IFizzBuzzViewModelMapper
    {

        public List<FizzBuzzViewModel> MapFrom(Dictionary<string, List<string>> source)
        {
            List<FizzBuzzViewModel> fizzBuzzViewModels = source.Select(kvpair => MapFrom(kvpair)).ToList();
            return fizzBuzzViewModels;
        }

        public FizzBuzzViewModel MapFrom(KeyValuePair<string, List<string>> source)
        {
            return new FizzBuzzViewModel()
            {
                InputFragment = source.Key,
                Results = source.Value
            };
        }
    }
}
