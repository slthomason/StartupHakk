using Microsoft.AspNetCore.Authorization;

namespace Sample
{
    public class DenyUserWithNameRequirement : AuthorizationHandler<DenyUserWithNameRequirement>, IAuthorizationRequirement
    {
        public string NotAllowedName { get; }
        public DenyUserWithNameRequirement(string notAllowedName)
        {
            NotAllowedName = notAllowedName;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            DenyUserWithNameRequirement requirement
            )
        {
            var userName = context.User.Identity?.Name;

            if(userName != null && userName == requirement.NotAllowedName)
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
