using Microsoft.Extensions.Logging;
using OrderHubCli;

public class OrderHubClient
{
    private readonly HttpClient _httpClient;
    private readonly UserProfile _userProfile;
    private readonly ILogger _logger;

    public OrderHubClient(HttpClient httpClient, UserProfile userProfile, ILogger logger)
    {
        _httpClient = httpClient;
        _userProfile = userProfile;
        _logger = logger;
    }

    public async Task<string> GetAsync(string url)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

        return await Request(requestMessage);
    }

    private async Task<string> Request(HttpRequestMessage requestMessage)
    {
        _httpClient.BaseAddress = new Uri(_host);

    }
}