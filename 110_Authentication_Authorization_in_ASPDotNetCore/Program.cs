using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Sample;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = "OurAuthenticationScheme";
    })
    .AddCookie("ExplicitSchemeName", options =>
    {
        options.Events.OnRedirectToLogin = context => {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = context => {
            context.Response.StatusCode = 403;
            return Task.CompletedTask;
        };
    })
    .AddScheme<AuthenticationSchemeOptions, OurDemoAuthenticationHandler>(
        "OurAuthenticationScheme", 
        _ => { });

builder.Services.AddSingleton<IAuthorizationHandler, PlainRequirementHandler>();
builder.Services.AddAuthorization(
    options =>
    {
        options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddRequirements(new DenyUserWithNameRequirement("Test deny"))
                .Build();
        options.AddPolicy(
            "ExplicitSchemePolicy", 
            new AuthorizationPolicyBuilder("ExplicitSchemeName")
                .RequireAuthenticatedUser()
                .AddRequirements(new PlainRequirement())
                .Build());
    }
    );

var app = builder.Build();

app.UseHttpsRedirection()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();

app.MapGet("auth", (HttpContext context) =>
{
    return Results.Ok(context.User?.Identity?.Name ?? "no user");
}).RequireAuthorization();
app.MapGet("auth/explicitScheme", (HttpContext context) =>
{
    return Results.Ok(context.User?.Identity?.Name ?? "no user");
}).RequireAuthorization("ExplicitSchemePolicy");
app.MapGet("noauth", (HttpContext context) =>
{
    return Results.Ok(context.User?.Identity?.Name ?? "no user");
});
app.MapGet("/logout", async (context) =>
{
    await context.SignOutAsync("ExplicitSchemeName");
});
app.MapGet("/login", async (context) =>
{
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Name, "Test User"),
        new Claim(ClaimTypes.Email, "")
    };
    var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "ExplicitSchemeName"));
    await context.SignInAsync("ExplicitSchemeName", principal);
});

app.Run();