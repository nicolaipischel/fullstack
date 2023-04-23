using System.Text;
using System.Text.Json;
using Api.Definitions;
using Microsoft.Extensions.Options;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Api.Implementations;

internal class JsonRepository<TDb, TDomain> : IRepository<TDb, TDomain> where TDb : class, IEntity, IMapTo<TDomain> where TDomain: class
{
    private Dictionary<Guid, TDb> _items = new();
    private readonly RepositoryOptions _options;

    public JsonRepository(IOptions<RepositoryOptions> options)
    {
        _options = options.Value;
        Load(_options.FilePath);
    }

    private void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(_items), new UTF8Encoding());
        }

        var json = File.ReadAllText(filePath, Encoding.UTF8);
        _items = JsonSerializer.Deserialize<Dictionary<Guid, TDb>>(json) ?? new Dictionary<Guid, TDb>();
    }
    
    public IEnumerable<TDomain> List()
    {
        return _items.Values.Select(v => v.Map());
    }

    public TDomain? Find(int id)
    {
        throw new NotImplementedException();
    }

    public Guid Create(TDb model)
    {
        _items.Add(model.Id, model);
        var json = JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true});
        File.WriteAllText(_options.FilePath, json, new UTF8Encoding());
        return model.Id;
    }

    public void Update(TDb model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}