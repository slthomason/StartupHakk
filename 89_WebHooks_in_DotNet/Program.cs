//Implementing a Webhok Server

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<WebhookService>();

var app = builder.Build();

app.MapPost("/subscribe", (WebhookService ws, Subscription sub) 
    => ws.Subscribe(sub));

app.Run();



public record Subscription(string Topic, string Callback);

public class WebhookService
{
    private readonly List<Subscription> _subscriptions = new();
    
    public void Subscribe(Subscription subscription)
    {
        _subscriptions.Add(subscription);
    }
}


//Adding the Trigger
app.MapPost("/publish", async (WebhookService ws, PublishRequest req) 
    => await ws.PublishMessage(req.Topic, req.Message));

record PublishRequest(string Topic, object Message);


public class WebhookService
{
    private readonly List<Subscription> _subscriptions = new();
    private readonly HttpClient _httpClient = new(); 
    
    public void Subscribe(Subscription subscription)
    {
        _subscriptions.Add(subscription);
    }

    public async Task PublishMessage(string topic, object message)
    {
        var subscribedWebhooks = _subscriptions.Where(w => w.Topic == topic);
        
        foreach (var webhook in subscribedWebhooks)
        {
            await _httpClient.PostAsJsonAsync(webhook.Callback, message);
        }
    }
}

//Implementing a Webhook Client

const string server = "http://localhost:5003";
const string callback = "http://localhost:5004/wh/item/new";
const string topic = "item.new";

var client = new HttpClient();

Console.WriteLine($"Subscribing to topic {topic} with callback {callback}");
await client.PostAsJsonAsync(server + "/subscribe", new { topic, callback });

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();

var app = builder.Build();
app.MapPost("/wh/item/new", (object payload, ILogger<Program> logger) =>
{
    logger.LogInformation("Received payload: {payload}", payload);
});
app.Run();

//Triggering the Webhook

// $body = @{
//     Topic = "item.new"
//     Message = @{
//         Name = "Some Item"
//         Price = "2.55"
//     }
// } | ConvertTo-Json

// Invoke-RestMethod -Uri "http://localhost:5003/publish" -Method POST -Body $body -ContentType "application/json"


/*
info: Program[0]
      Received payload: {"Price":"2.55","Name":"Some Item"}*/



