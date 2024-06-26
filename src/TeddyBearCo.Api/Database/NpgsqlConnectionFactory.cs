﻿using Npgsql;
using System.Data;

namespace TeddyBearCo.Api.Database;

public class NpgsqlConnectionFactory : IDbConnectionFactory
{
	private readonly string _connectionString;

	public NpgsqlConnectionFactory(string connectionString)
	{
		_connectionString = connectionString;
	}

	public async Task<IDbConnection> CreateConnectionAsync()
	{
		var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();
		return connection;
	}
}
