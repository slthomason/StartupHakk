using Microsoft.AspNetCore.Authorization;

namespace Sample
{
    public class PlainRequirementHandler : AuthorizationHandler<PlainRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PlainRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
