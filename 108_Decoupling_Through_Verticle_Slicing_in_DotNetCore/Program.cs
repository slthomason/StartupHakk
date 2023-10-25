using VerticalSlicedMinimalApi.API.Endpoints;
using VerticalSlicedMinimalApi.Infrastructure.DataStore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton<FakeDbContext>();

var app = builder.Build();
app.MapGet("/", () => "Server is running");
app.MapGroup("/api/v1").CompanyEndpoints();

app.Run();