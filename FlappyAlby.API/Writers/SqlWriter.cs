namespace FlappyAlby.API.Writers;

using Abstract;
using Dapper;
using Domain;
using FlappyAlby.API.Options;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

public class SqlWriter : IWriter
{
    private readonly string _connectionString;

    public SqlWriter(IOptions<ConnectionStringOptions> options)
    {
        _connectionString = options.Value.DefaultDatabase;
    }
    public async Task<bool> WriteAsync<TEntity>(string query, TEntity objectToBindToQuery) where TEntity : EntityBase
    {
        await using var connection = new SqlConnection(_connectionString);
        var affectedRows = await connection.ExecuteAsync(query, objectToBindToQuery, commandTimeout: 10);
        return affectedRows > 0;
    }
}
