namespace FlappyAlby.API.Abstract;

using Domain;
public interface IReader
{
    public Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string query) where TEntity : EntityBase;
}

