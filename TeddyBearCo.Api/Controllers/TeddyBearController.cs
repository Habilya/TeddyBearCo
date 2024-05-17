using Microsoft.AspNetCore.Mvc;
using TeddyBearCo.Api.Contracts.Requests;
using TeddyBearCo.Api.Mapping.ApiContract;
using TeddyBearCo.Api.Services;

namespace TeddyBearCo.Api.Controllers;

[ApiController]
public class TeddyBearController : ControllerBase
{
	private readonly ITeddyBearService _teddyBearService;

	public TeddyBearController(ITeddyBearService teddyBearService)
	{
		_teddyBearService = teddyBearService;
	}

	[HttpPost("teddybears")]
	public async Task<IActionResult> Create([FromBody] TeddyBearRequest request)
	{
		var teddyBear = request.ToTeddyBear();

		await _teddyBearService.CreateAsync(teddyBear);

		var teddyBearResponse = teddyBear.ToTeddyBearResponse();

		return CreatedAtAction("Get", new { teddyBearResponse.Id }, teddyBearResponse);
	}
}
