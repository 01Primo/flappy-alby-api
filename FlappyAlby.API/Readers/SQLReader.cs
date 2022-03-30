﻿namespace FlappyAlby.API.Readers;

using FlappyAlby.API.Abstract;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using Options;
using Dapper;

public class SQLReader : IReader
{
    private readonly string _connectionstring;
    public SQLReader(IOptions<ConnectionStringOptions> options)
    {
        _connectionstring = options.Value.DefaultDatabase;
    }

    public async Task<IEnumerable<TEntity>> QueryTEntityAsync<TEntity>(string query) =>
        await new SqlConnection(_connectionstring).QueryAsync<TEntity>(query, commandType: CommandType.Text, commandTimeout: 10);

    public async Task<TEntity> QuerySingleTEntityAsync<TEntity>(string query, object parameters) =>
        await new SqlConnection(_connectionstring).QuerySingleOrDefaultAsync<TEntity>(query, parameters, commandType: CommandType.Text, commandTimeout: 10);
}