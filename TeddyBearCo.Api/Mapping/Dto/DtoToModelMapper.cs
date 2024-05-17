using System.Globalization;
using TeddyBearCo.Api.Contracts.Dto;
using TeddyBearCo.Api.Models;

namespace TeddyBearCo.Api.Mapping.Dto;

public static class DtoToModelMapper
{
	public static TeddyBear ToTeddyBear(this TeddyBearDto teddyBearDto)
	{
		return new TeddyBear
		{
			Id = teddyBearDto.Id,
			Email = teddyBearDto.Email,
			Username = teddyBearDto.Username,
			FirstName = teddyBearDto.FirstName,
			LastName = teddyBearDto.LastName,
			DateOfBirth = DateTime.ParseExact(teddyBearDto.DateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture)
		};
	}
}
