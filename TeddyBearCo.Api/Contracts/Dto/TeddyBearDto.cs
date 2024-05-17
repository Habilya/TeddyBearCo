namespace TeddyBearCo.Api.Contracts.Dto;

public class TeddyBearDto
{
	public Guid Id { get; init; } = default!;

	public string Username { get; init; } = default!;

	public string FirstName { get; init; } = default!;

	public string LastName { get; init; } = default!;

	public string Email { get; init; } = default!;

	public string DateOfBirth { get; init; } = default!;
}
