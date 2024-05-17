using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TeddyBearCo.Api.Contracts.Requests;
using TeddyBearCo.Api.Contracts.Responses;
using TeddyBearCo.Api.Controllers;
using TeddyBearCo.Api.Mapping.ApiContract;
using TeddyBearCo.Api.Models;
using TeddyBearCo.Api.Services;

namespace TeddyBearCo.Api.Tests.Unit;

public class TeddyBearControllerTests
{
	private readonly TeddyBearController _sut;
	private readonly ITeddyBearService _teddyBearService = Substitute.For<ITeddyBearService>();


	public TeddyBearControllerTests()
	{
		_sut = new TeddyBearController(_teddyBearService);
	}

	[Fact]
	public async Task Create_ShouldCreateTeddyBear_WhenCreateTeddyBearRequestIsValid()
	{
		// Arrange
		var createTeddyBearRequest = new TeddyBearRequest
		{
			FirstName = "TestA",
			LastName = "TestB",
			Username = "TestUser",
			DateOfBirth = new DateTime(2022, 2, 2),
			Email = "testemail@email.com"
		};

		var teddyBear = new TeddyBear
		{
		};

		_teddyBearService.CreateAsync(Arg.Do<TeddyBear>(x => teddyBear = x)).Returns(true);

		// Act
		var result = (CreatedAtActionResult)await _sut.Create(createTeddyBearRequest);

		// Assert
		var expectedTeddyBearResponse = teddyBear.ToTeddyBearResponse();
		result.StatusCode.Should().Be(201);
		result.Value.As<TeddyBearResponse>().Should().BeEquivalentTo(expectedTeddyBearResponse);
		result.RouteValues!["id"].Should().Be(teddyBear.Id);
	}

	[Fact]
	public async Task Create_ShouldReturnBadRequest_WhenCreateTeddyBearRequestIsInvalid()
	{
		// Arrange
		_teddyBearService.CreateAsync(Arg.Any<TeddyBear>()).Returns(false);

		// Act
		var result = (BadRequestResult)await _sut.Create(new TeddyBearRequest());

		// Assert
		result.StatusCode.Should().Be(400);
	}
}
