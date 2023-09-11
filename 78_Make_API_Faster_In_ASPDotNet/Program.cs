var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use the Output cache service, also we are specifying the cache duration, and use StackExchange Redis Cache where we specify our connection string.
builder.Services.AddOutputCache(opt => opt.DefaultExpirationTimeSpan = TimeSpan.FromMinutes(5))
                .AddStackExchangeRedisCache(opt =>
                {
                    opt.InstanceName = "TodosAPI";
                    opt.Configuration = "localhost:7244"; // Use your connection string
                });

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.UseOutputCache();

app.MapGet("/todos", async () =>
{
    using var httpClient = new HttpClient();
    var response = await httpClient.GetFromJsonAsync<Todo[]>("https://jsonplaceholder.typicode.com/todos");

    return Results.Ok(response);

}).CacheOutput(); // Don't forget to add this extension method to enable caching for this endpoint, you can also determine the cache duration in this function.


app.Run();
public record Todo(int Id, int UserId, string Title, bool Completed);
