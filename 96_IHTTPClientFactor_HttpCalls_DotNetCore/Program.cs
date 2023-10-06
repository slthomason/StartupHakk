//Use IHttpClientFactory directly
services.AddHttpClient();

private readonly IHttpClientFactory _httpClientFactory;
public UseHttpClientFactoryDirectController(IHttpClientFactory httpClientFactory)
{
    _httpClientFactory = httpClientFactory;
}

[HttpGet]
[Route("get")]
public async Task<string> Get()
{
    try
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://www.google.com");
        string result = await client.GetStringAsync("/");
        return result;
    }
    catch (Exception ex)
    {
        throw ex;
    }
}


//Named Type 
services.AddHttpClient("namedType", c =>
{
    c.BaseAddress = new Uri("https://www.google.com/");
    c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
    c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
});

private readonly IHttpClientFactory _httpClientFactory;
public NamedTypeController(IHttpClientFactory httpClientFactory)
{
    _httpClientFactory = httpClientFactory;
}

[HttpGet]
[Route("get")]
public async Task<string> Get()
{
    try
    {
        var client = _httpClientFactory.CreateClient("namedType");
        client.BaseAddress = new Uri("https://www.google.com");
        string result = await client.GetStringAsync("/");
        return result;
    }
    catch (Exception ex)
    {
        throw ex;
    }
}


//Typed Client
services.AddHttpClient<ITypedClient, TypedClientService>();

public class TypedClientService : ITypedClient
{
    private HttpClient _httpClient;
    public TypedClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<string> Get()
    {
        var url= new Uri("https://www.google.com");
        var response= await _httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}


private ITypedClient _typedClientService;
public TypedClientController(ITypedClient typedClientService)
{
    _typedClientService = typedClientService;
}

[HttpGet]
[Route("get")]
public async Task<string> Get()
{
    try
    {
        return await _typedClientService.Get();
    }
    catch (Exception ex)
    {
        throw ex;
    }
}


//How to declare multiple IHttpClientFactory?

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    //Use IHttpClientFactory directly
    services.AddHttpClient();

    //Named Type 
    services.AddHttpClient("namedType", c =>
    {
        c.BaseAddress = new Uri("https://www.google.com/");
        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
    });

    //Typed Client
    services.AddHttpClient<ITypedClient, TypedClientService>();
}