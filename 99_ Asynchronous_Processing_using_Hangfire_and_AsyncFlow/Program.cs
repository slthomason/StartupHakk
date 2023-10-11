builder.Services.AddHangfire(x => x.UseMemoryStorage());
builder.Services.AddHangfireServer();
builder.Services.AddMemoryCache();
builder.Services.AddAsyncFlow(options => options.UseMemoryCache());


public class GenerateDataJob : IAsyncFlow<GenerateDataRequest, GenerateDataResponse>
{
    public async Task<GenerateDataResponse> ProcessAsync(GenerateDataRequest request)
    {
       var result = new GenerateDataResponse
        {
            Data = $"Generated data for {request.InputParameter}"
        };
        await Task.Delay(1000); // Simulate some async work
        return result;
    }
}
public class GenerateDataRequest
{
    public string InputParameter { get; set; }
}
public class GenerateDataResponse
{
    public string Data { get; set; }
}


builder.Services.AddTransient<GenerateDataJob>();

app.MapFlow<GenerateDataJob, GenerateDataRequest, GenerateDataResponse>("data");



app.UseHangfireDashboard();

