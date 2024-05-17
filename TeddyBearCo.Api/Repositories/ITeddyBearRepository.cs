using TeddyBearCo.Api.Contracts.Dto;

namespace TeddyBearCo.Api.Repositories
{
	public interface ITeddyBearRepository
	{
		Task<bool> CreateAsync(TeddyBearDto teddyBear);
		Task<bool> DeleteAsync(Guid id);
		Task<IEnumerable<TeddyBearDto>> GetAllAsync();
		Task<TeddyBearDto?> GetAsync(Guid id);
		Task<bool> UpdateAsync(TeddyBearDto teddyBear);
	}
}