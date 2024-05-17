using TeddyBearCo.Api.Contracts.Dto;
using TeddyBearCo.Api.Models;

namespace TeddyBearCo.Api.Mapping.Dto;

public static class ModelToDtoMapper
{
	public static TeddyBearDto ToTeddyBearDto(this TeddyBear teddyBear)
	{
		return new TeddyBearDto
		{
			Id = teddyBear.Id,
			Email = teddyBear.Email,
			Username = teddyBear.Username,
			FirstName = teddyBear.FirstName,
			LastName = teddyBear.LastName,
			DateOfBirth = teddyBear.DateOfBirth.ToString("yyyy-MM-dd"),
		};
	}
}
