namespace FizzBuzzSample.Core.Interfaces
{
    public interface IMap<TTarget, TSource>
    {
        TTarget MapFrom(TSource source);
    }
}
