namespace Api.Definitions;

public interface IRepository<in TDb, out TDomain> where TDb: class, IEntity, IMapTo<TDomain> where TDomain : class
{
    IEnumerable<TDomain> List();
    TDomain? Find(int id);
    Guid Create(TDb model);
    void Update(TDb model);
    void Delete(int id);
}