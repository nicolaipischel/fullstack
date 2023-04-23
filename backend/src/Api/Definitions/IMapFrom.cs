namespace Api.Definitions;

public interface IMapFrom<in TInput, out TOutput> where TInput : class
{
    public static abstract TOutput MapFrom(TInput input);
}