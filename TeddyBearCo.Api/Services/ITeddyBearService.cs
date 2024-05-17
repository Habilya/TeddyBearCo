using TeddyBearCo.Api.Models;

namespace TeddyBearCo.Api.Services;

public interface ITeddyBearService
{
	Task<bool> CreateAsync(TeddyBear teddyBear);

	Task<bool> DeleteAsync(Guid id);

	Task<TeddyBear?> GetAsync(Guid id);

	Task<bool> UpdateAsync(TeddyBear teddyBear);
}
