namespace WebApi.Stores;

using System.Collections.Concurrent;
using WebApi.Models;

public interface IStore
{
    void Save(Output output);

    Output GetById(Guid id);

    List<Output> GetAll();
}

internal sealed class Store : IStore
{
    private static readonly ConcurrentDictionary<Guid, Output> Db = new();

    public void Save(Output output) => Db[output.Id] = output;

    public Output GetById(Guid id) => Db.GetValueOrDefault(id);

    public List<Output> GetAll() => Db.Select(x => x.Value).ToList();
}