using System.Threading.Tasks;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Workshop.Accounts.Api.Domain;

namespace Workshop.Accounts.Api.Authorization
{
    public class UsersAuthorizationHandler : AuthorizationHandler<PeopleRequirement, IResolverContext>
    {
        readonly UserAuthorizationService _service;

        public UsersAuthorizationHandler(UserAuthorizationService service)
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