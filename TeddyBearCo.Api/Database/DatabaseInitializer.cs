using Dapper;

namespace TeddyBearCo.Api.Database;

public class DatabaseInitializer
{
	private readonly IDbConnectionFactory _connectionFactory;

	public DatabaseInitializer(IDbConnectionFactory connectionFactory)
	{
		_connectionFactory = connectionFactory;
	}

	public async Task InitializeAsync()
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();
		await connection.ExecuteAsync(
		@"CREATE TABLE IF NOT EXISTS TeddyBears (
			Id UUID PRIMARY KEY, 
			Username TEXT NOT NULL,
			FirstName TEXT NOT NULL,
			LastName TEXT NOT NULL,
			Email TEXT NOT NULL,
			DateOfBirth TEXT NOT NULL)"
		);
	}
}
