//HttpClient and BaseUri: A Love Story

var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://my-url-goes-here.com");



//Retrieving BaseUri inside your web application: NavigationManager

[Inject] NavigationManager NavigationManager { get; set; }
 private List<string> _fetchedData = new();

 // Let's fetch the current request / base url information from the injected NavigationManager
 private async Task FetchApiData()
 {
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri(NavigationManager.BaseUri);
    var results = await httpClient.GetAsync("values");

   var valuesFoundFromApi = await results.Content.ReadFromJsonAsync<List<string>>();

   _fetchedData.Clear();
   if (valuesFoundFromApi != null) 
       _fetchedData.AddRange(valuesFoundFromApi);
 }


//Retrieving BaseUri inside your web application: IHttpContextAccessor

 // Get the http context accessor auto-injected into your app's IoC
//Program.cs
builder.Services.AddHttpContextAccessor();

//Older-school Startup.cs
public void ConfigureServices(IServiceCollection services)
{
...
services.AddHttpContextAccessor();
}

public class ValuesApiClient : IValuesApiClient
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ValuesApiClient(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<List<string>?> GetValuesAsync()
    {
        var httpClient = new HttpClient();
        var request = _httpContextAccessor.HttpContext!.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";

        httpClient.BaseAddress = new Uri(baseUrl);
        ...
    }
}


//Retrieving BaseUri inside your web application with no Http Request involved: WebHostDefaults.ServerUrlsKey

var configuredWebsiteUrls = builder.WebHost.GetSetting(WebHostDefaults.ServerUrlsKey);


"applicationUrl": "https://localhost:7299;http://localhost:5299"


public interface IHttpBaseUrlAccessor
{
    string? SiteUrlString { get; set; }
    string? GetHttpsUrl();
    string? GetHttpUrl();
}


public class HttpBaseUrlAccessor : IHttpBaseUrlAccessor
{
    public string? SiteUrlString { get; set; } = string.Empty;

    public string? GetHttpsUrl()
    {
        var urls = SiteUrlString.Split(";");

        return urls.FirstOrDefault(g => g.StartsWith("https://"));
    }

    public string? GetHttpUrl()
    {
        var urls = SiteUrlString.Split(";");

        return urls.FirstOrDefault(g => g.StartsWith("http://"));
    }
}


// Get the Base URLs of this app so we can use it internally if need be
var httpBaseUriAccessor = new HttpBaseUrlAccessor()
{
   SiteUrlString = builder.WebHost.GetSetting(WebHostDefaults.ServerUrlsKey)
};

builder.Services.AddSingleton<IHttpBaseUrlAccessor>(httpBaseUriAccessor);


[Inject] IHttpBaseUrlAccessor BaseUrlAccessor { get; set; }

 var httpClient = new HttpClient();
        var baseUrl = BaseUrlAccessor.GetHttpsUrl() ?? BaseUrlAccessor.GetHttpUrl();
        if (baseUrl != null && !string.IsNullOrEmpty(baseUrl))
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            //...use the httpClient etc.
        }