namespace FlappyAlby.API.Readers;

using Abstract;
using Domain;
using Options;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Dapper;

public class SqlReader : IReader
{
    private readonly string _connectionString;
    public SqlReader(IOptions<ConnectionStringOptions> options)
    {
        _connectionString = options.Value.DefaultDatabase;
    }
    public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string query) where TEntity : EntityBase
    {
        await using var conn = new SqlConnection(_connectionString);
        return await conn.QueryAsync<TEntity>(query, commandType: CommandType.Text, commandTimeout: 10);
    }
}
