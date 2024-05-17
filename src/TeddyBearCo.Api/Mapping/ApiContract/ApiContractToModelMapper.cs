using TeddyBearCo.Api.Contracts.Requests;
using TeddyBearCo.Api.Models;

namespace TeddyBearCo.Api.Mapping.ApiContract;

public static class ApiContractToModelMapper
{
	public static TeddyBear ToTeddyBear(this TeddyBearRequest request)
	{
		return new TeddyBear
		{
			Id = Guid.NewGuid(),
			Email = request.Email,
			Username = request.Username,
			FirstName = request.FirstName,
			LastName = request.LastName,
			DateOfBirth = request.DateOfBirth
		};
	}

	public static TeddyBear ToTeddyBear(this UpdateTeddyBearRequest request)
	{
		return new TeddyBear
		{
			Id = request.Id,
			Email = request.TeddyBear.Email,
			Username = request.TeddyBear.Username,
			FirstName = request.TeddyBear.FirstName,
			LastName = request.TeddyBear.LastName,
			DateOfBirth = request.TeddyBear.DateOfBirth
		};
	}
}
