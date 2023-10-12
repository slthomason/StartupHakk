var client = new HttpClient { BaseAddress = new Uri("http://localhost:8080") };
var item = new Item(5, "Item 5");

var postResponse = await client.PostAsJsonAsync("/items", item);
var putResponse = await client.PutAsJsonAsync("/items/5", item);
var patchResponse = await client.PatchAsJsonAsync("/items", new {});
var getResponse = await client.GetFromJsonAsync<Item>("/items/5");
var deleteResponse = await client.DeleteAsync("/items/5");


//IHttpClientFactory

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

// ItemService.cs

public class ItemService
{
    private readonly HttpClient _client;

    public ItemService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5266/");
    }

    public async Task<Item?> GetItem(int id)
    {
        return await _client.GetFromJsonAsync<Item>($"items/{id}");
    }
}

//Named Clients

// Program.cs

services.AddHttpClient("Local", client =>
{
    client.BaseAddress = new Uri("http://localhost:5266/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.Timeout = TimeSpan.FromSeconds(15);
});

// ItemService.cs

public ItemService(IHttpClientFactory clientFactory)
{
    _client = clientFactory.CreateClient("Local");
}


//Controllers
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateItem(Item item) => Ok(item);
    
    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, Item item) => Ok(item);
    
    [HttpGet("{id}")]
    public IActionResult GetItem(int id) => Ok(new Item());

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id) => Ok();
    
    [HttpPatch("{id}")]
    public IActionResult PatchItem(JsonPatchDocument<Item> patchDoc) => Ok();
}


//Minimal APIs

var app = WebApplication.Create(args);

app.MapPost("/items", (Item item) => Results.Ok(item));
app.MapPut("/items/{id}", (int id, Item item) => Results.Ok(item));
app.MapGet("/items/{id}", (int id) => Results.Ok(new Item()));
app.MapDelete("/items/{id}", (int id) => Results.Ok());
app.MapPatch("/items", (JsonPatchDocument<Item> patchDoc) => Results.Ok());

app.Run();

//Injecting Dependencies

builder.Services.AddTransient<ItemService>();

app.MapGet("/items/{id}", async (int id, [FromServices] ItemService itemService) =>
{
    var item = await itemService.GetItem(id);
    return Results.Ok(item);
});