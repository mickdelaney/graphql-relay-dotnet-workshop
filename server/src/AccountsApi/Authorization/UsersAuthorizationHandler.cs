using System.Threading.Tasks;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Workshop.Accounts.Api.Domain;

namespace Workshop.Accounts.Api.Authorization
{
    public class UserAuthorizationHandler : AuthorizationHandler<PeopleRequirement, IResolverContext>
    {
        readonly PeopleAuthorizationService _service;

        public UserAuthorizationHandler(PeopleAuthorizationService service)
        {
            _service = service;
        }
        
        protected override Task HandleRequirementAsync
        (
            AuthorizationHandlerContext context,
            PeopleRequirement requirement,
            IResolverContext resource
        )
        {
            var person = resource.Parent<User>();
            
            context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}