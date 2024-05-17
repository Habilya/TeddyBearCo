using Microsoft.AspNetCore.Mvc;

namespace TeddyBearCo.Api.Contracts.Requests;

public class UpdateTeddyBearRequest
{
	[FromRoute(Name = "id")] public Guid Id { get; init; }

	[FromBody] public TeddyBearRequest TeddyBear { get; set; } = default!;
}
