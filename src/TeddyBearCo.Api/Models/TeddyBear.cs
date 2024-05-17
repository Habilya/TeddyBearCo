namespace TeddyBearCo.Api.Models;

public class TeddyBear
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public string Username { get; init; } = default!;

	public string FirstName { get; init; } = default!;

	public string LastName { get; init; } = default!;

	public DateTime DateOfBirth { get; init; } = default!;

	public string Email { get; init; } = default!;
}
