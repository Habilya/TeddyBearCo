using NSubstitute;
using TeddyBearCo.Api.Contracts.Dto;
using TeddyBearCo.Api.Models;
using TeddyBearCo.Api.Repositories;
using TeddyBearCo.Api.Services;

namespace TeddyBearCo.Api.Tests.Unit;

public class TeddyBearServiceTests
{
	private readonly TeddyBearService _sut;
	private readonly ITeddyBearRepository _teddyBearRepository = Substitute.For<ITeddyBearRepository>();

	public TeddyBearServiceTests()
	{
		_sut = new TeddyBearService(_teddyBearRepository);
	}

	[Fact]
	public async Task CreateAsync_ShouldCreateUser_WhenDetailsAreValid()
	{
		// Arrange
		var guid = Guid.NewGuid();
		var teddyBearModel = new TeddyBear
		{
			Id = guid,
			FirstName = "TestA",
			LastName = "TestB",
			Username = "TestUser",
			DateOfBirth = new DateTime(2022, 2, 2),
			Email = "testemail@email.com"

		};

		_teddyBearRepository.CreateAsync(Arg.Any<TeddyBearDto>()).Returns(true);

		// Act
		await _sut.CreateAsync(teddyBearModel);

		// Assert
		await _teddyBearRepository.Received(1)
			.CreateAsync(Arg.Is<TeddyBearDto>(q =>
				q.Id == guid
				&& q.FirstName == "TestA"
				&& q.LastName == "TestB"
				&& q.Username == "TestUser"
				&& q.DateOfBirth == "2022-02-02"
				&& q.Email == "testemail@email.com"
			));
	}
}
