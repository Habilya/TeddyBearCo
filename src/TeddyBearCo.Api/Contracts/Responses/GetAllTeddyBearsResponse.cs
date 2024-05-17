namespace TeddyBearCo.Api.Contracts.Responses;

public class GetAllTeddyBearsResponse
{
	public IEnumerable<TeddyBearResponse> TeddyBears { get; init; } = Enumerable.Empty<TeddyBearResponse>();
}
