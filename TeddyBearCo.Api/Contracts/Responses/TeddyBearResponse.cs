namespace TeddyBearCo.Api.Contracts.Responses;

public class TeddyBearResponse
{
	public Guid Id { get; init; }

	public string Username { get; init; } = default!;

	public string FirstName { get; init; } = default!;

	public string LastName { get; init; } = default!;

	public string Email { get; init; } = default!;

	public DateTime DateOfBirth { get; init; }
}
