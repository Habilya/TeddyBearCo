using TeddyBearCo.Api.Mapping.Dto;
using TeddyBearCo.Api.Models;
using TeddyBearCo.Api.Repositories;

namespace TeddyBearCo.Api.Services;

public class TeddyBearService : ITeddyBearService
{
	private readonly ITeddyBearRepository _teddyBearRepository;


	public TeddyBearService(ITeddyBearRepository teddyBearRepository)
	{
		_teddyBearRepository = teddyBearRepository;
	}

	public async Task<bool> CreateAsync(TeddyBear teddyBear)
	{
		var existingTeddyBear = await _teddyBearRepository.GetAsync(teddyBear.Id);
		if (existingTeddyBear is not null)
		{
			// good place to log some error or throw exceptions
			return false;
		}

		var teddyBearDto = teddyBear.ToTeddyBearDto();
		return await _teddyBearRepository.CreateAsync(teddyBearDto);
	}

	public async Task<TeddyBear?> GetAsync(Guid id)
	{
		var teddyBearDto = await _teddyBearRepository.GetAsync(id);
		return teddyBearDto?.ToTeddyBear();
	}

	public async Task<bool> UpdateAsync(TeddyBear teddyBear)
	{
		var teddyBearDto = teddyBear.ToTeddyBearDto();

		// Good place to add validation

		return await _teddyBearRepository.UpdateAsync(teddyBearDto);
	}

	public async Task<bool> DeleteAsync(Guid id)
	{
		return await _teddyBearRepository.DeleteAsync(id);
	}
}
