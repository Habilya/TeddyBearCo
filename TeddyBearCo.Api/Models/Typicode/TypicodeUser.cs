namespace TeddyBearCo.Api.Models.Typicode;

public class TypicodeUser
{
	public int Id { get; init; } = default!;
	public string Name { get; init; } = default!;
	public string Username { get; init; } = default!;
	public string Email { get; init; } = default!;
	public Address Address { get; init; } = default!;
	public string Phone { get; init; } = default!;
	public string Website { get; init; } = default!;
	public Company Company { get; init; } = default!;
}
