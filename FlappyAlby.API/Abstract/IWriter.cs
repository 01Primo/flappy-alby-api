namespace FlappyAlby.API.Abstract;

using Domain;
public interface IWriter
{
    public Task<bool> WriteAsync<TEntity>(string query, TEntity objectToBindToQuery) where TEntity : EntityBase;
}
