using TeddyBearCo.Api.Models.Typicode;

namespace TeddyBearCo.Api.Services;

public interface ITypicodeService
{
	Task<IEnumerable<TypicodeUser>> GetAllUsersAsync();
}
