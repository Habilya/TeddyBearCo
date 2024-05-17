using Dapper;
using TeddyBearCo.Api.Contracts.Dto;
using TeddyBearCo.Api.Database;

namespace TeddyBearCo.Api.Repositories;

public class TeddyBearRepository : ITeddyBearRepository
{
	private readonly IDbConnectionFactory _connectionFactory;

	public TeddyBearRepository(IDbConnectionFactory connectionFactory)
	{
		_connectionFactory = connectionFactory;
	}


	public async Task<bool> CreateAsync(TeddyBearDto teddyBear)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();
		var result = await connection.ExecuteAsync(
			@"INSERT INTO TeddyBears (Id, Username, FirstName, LastName, Email, DateOfBirth) 
			VALUES (@Id, @Username, @FirstName, @LastName, @Email, @DateOfBirth)",
			teddyBear);
		return result > 0;
	}

	public async Task<TeddyBearDto?> GetAsync(Guid id)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();
		return await connection.QuerySingleOrDefaultAsync<TeddyBearDto>(
			"SELECT * FROM TeddyBears WHERE Id = @Id LIMIT 1", new { Id = id });
	}

	public async Task<IEnumerable<TeddyBearDto>> GetAllAsync()
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();
		return await connection.QueryAsync<TeddyBearDto>("SELECT * FROM TeddyBears");
	}

	public async Task<bool> UpdateAsync(TeddyBearDto teddyBear)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();
		var result = await connection.ExecuteAsync(
			@"UPDATE TeddyBears SET 
				Username = @Username, 
				FirstName = @FirstName, 
				LastName = @LastName, 
				Email = @Email, 
				DateOfBirth = @DateOfBirth 
			WHERE Id = @Id",
			teddyBear);
		return result > 0;
	}

	public async Task<bool> DeleteAsync(Guid id)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();
		var result = await connection.ExecuteAsync(@"DELETE FROM TeddyBears WHERE Id = @Id",
			new { Id = id });
		return result > 0;
	}
}
