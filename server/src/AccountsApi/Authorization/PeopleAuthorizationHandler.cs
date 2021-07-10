using System.Threading.Tasks;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Workshop.AccountsApi.Domain;

namespace Workshop.AccountsApi.Authorization
{
    public class PeopleAuthorizationHandler : AuthorizationHandler<PeopleRequirement, IResolverContext>
    {
        readonly PeopleAuthorizationService _service;

        public PeopleAuthorizationHandler(PeopleAuthorizationService service)
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
            var person = resource.Parent<Person>();
            
            context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}