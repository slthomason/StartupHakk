using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Sample
{
    [Authorize]
    public class OurDemoAuthenticationHandler
        : SignInAuthenticationHandler<AuthenticationSchemeOptions>,
        IAuthenticationRequestHandler
    {
        public OurDemoAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> 
            options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        public async Task<bool> HandleRequestAsync()
        {
            var requestPath = Context.Request.Path;
            if (requestPath == "/ourlogin/deny")
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, "Test deny"),
                        new Claim(ClaimTypes.Email, "")
                    };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));
                await Context.SignInAsync(Scheme.Name, principal);
                return true;
            }
            if (requestPath == "/ourlogin")
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, "Test OwnAuthentication User"),
                        new Claim(ClaimTypes.Email, "")
                    };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));
                await Context.SignInAsync(Scheme.Name, principal);
                return true;
            }
            if (requestPath == "/ourlogout")
            {
                await Context.SignOutAsync(Scheme.Name);
                return true;
            }

            return false;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Cookies.TryGetValue("OurAuthentication", out var authCookieValue)
                || authCookieValue == null
                )
            {
                return AuthenticateResult.Fail("no user"); ;
            }

            var userPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, authCookieValue) },
                    Scheme.Name)
                );

            return AuthenticateResult.Success(
                new AuthenticationTicket(
                    userPrincipal,
                    new AuthenticationProperties(),
                    Scheme.Name)
                );
        }

        protected override async Task HandleSignInAsync(ClaimsPrincipal user, AuthenticationProperties? properties)
        {
            Context.Response.OnStarting(async () =>
            {
                Context.Response.Cookies.Append("OurAuthentication", user.Identity?.Name);
                await Task.CompletedTask;
            });

            await Task.CompletedTask;
        }

        protected override async Task HandleSignOutAsync(AuthenticationProperties? properties)
        {
            Context.Response.OnStarting(async () =>
            {
                Context.Response.Cookies.Delete("OurAuthentication");
                await Task.CompletedTask;
            });

            await Task.CompletedTask;
        }
    }
}
