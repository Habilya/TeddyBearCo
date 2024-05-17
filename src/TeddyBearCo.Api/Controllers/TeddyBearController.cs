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

	[HttpGet("teddybears/{id:guid}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var teddyBear = await _teddyBearService.GetAsync(id);
		if (teddyBear is null)
		{
			return NotFound();
		}

		var teddyBearResponse = teddyBear.ToTeddyBearResponse();

		return Ok(teddyBearResponse);
	}

	[HttpPost("teddybears")]
	public async Task<IActionResult> Create([FromBody] TeddyBearRequest request)
	{
		var teddyBear = request.ToTeddyBear();

		var created = await _teddyBearService.CreateAsync(teddyBear);
		if (!created)
		{
			// Possibly a good place to Implement logging
			return BadRequest();
		}

		var teddyBearResponse = teddyBear.ToTeddyBearResponse();

		return CreatedAtAction(nameof(GetById), new { id = teddyBearResponse.Id }, teddyBearResponse);
	}
}
