using System.Data;

namespace TeddyBearCo.Api.Database;

public interface IDbConnectionFactory
{
	public Task<IDbConnection> CreateConnectionAsync();
}
