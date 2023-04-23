namespace Api.Definitions;

public interface IMapTo<out TOutput> where TOutput : class
{
    public TOutput Map();
}