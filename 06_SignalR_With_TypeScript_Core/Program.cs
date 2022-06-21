
using _06_SignalR_With_TypeScript_Core.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();


app.MapHub<ChatHub>("/hub");

app.Run();
