using TeddyBearCo.Api.Models.Typicode;

namespace TeddyBearCo.Api.Services;

public class TypicodeService : ITypicodeService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly HttpClient _httpClient;

	public TypicodeService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
		_httpClient = _httpClientFactory.CreateClient("TypicodeApi");
	}

	public async Task<IEnumerable<TypicodeUser>> GetAllUsersAsync()
	{
		var response = await _httpClient.GetAsync("/users");
		var responseBody = await response.Content.ReadFromJsonAsync<IEnumerable<TypicodeUser>>();
		return responseBody ?? new List<TypicodeUser>();
	}
}
