using TeddyBearCo.Api.Contracts.Responses;
using TeddyBearCo.Api.Models;

namespace TeddyBearCo.Api.Mapping.ApiContract;

public static class ModelToApiContractMapper
{
	public static TeddyBearResponse ToTeddyBearResponse(this TeddyBear teddyBear)
	{
		return new TeddyBearResponse
		{
			Id = teddyBear.Id,
			Email = teddyBear.Email,
			Username = teddyBear.Username,
			FirstName = teddyBear.FirstName,
			LastName = teddyBear.LastName,
			DateOfBirth = teddyBear.DateOfBirth
		};
	}

	public static GetAllTeddyBearsResponse ToTeddyBearsResponse(this IEnumerable<TeddyBear> teddyBears)
	{
		return new GetAllTeddyBearsResponse
		{
			TeddyBears = teddyBears.Select(x => new TeddyBearResponse
			{
				Id = x.Id,
				Email = x.Email,
				Username = x.Username,
				FirstName = x.FirstName,
				LastName = x.LastName,
				DateOfBirth = x.DateOfBirth
			})
		};
	}
}
