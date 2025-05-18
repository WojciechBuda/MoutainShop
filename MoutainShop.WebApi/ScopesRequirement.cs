using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;

namespace MoutainShop.WebApi
{
    public class ScopesRequirement(params string[] acceptedScopes)
    : AuthorizationHandler<ScopesRequirement>, IAuthorizationRequirement
    {
        readonly string[] acceptedScopes = acceptedScopes;

        /// <summary>
        /// AuthorizationHandler that will check if the scope claim has at least one of the requirement values
        /// </summary>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                        ScopesRequirement requirement)
        {
            // If there are no scopes, do not process
            if (context.User.Claims.All(x => x.Type != ClaimConstants.Scope) && context.User.Claims.All(y => y.Type != ClaimConstants.Scp))
            {
                return Task.CompletedTask;
            }

            var scopeClaim = context?.User?.FindFirst(ClaimConstants.Scp) ?? context?.User?.FindFirst(ClaimConstants.Scope);

            if (scopeClaim != null && scopeClaim.Value.Split(' ').Intersect(requirement.acceptedScopes).Any())
            {
                context?.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
