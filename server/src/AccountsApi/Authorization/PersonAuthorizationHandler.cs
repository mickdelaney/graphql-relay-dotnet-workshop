﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Workshop.AccountsApi.Domain;

namespace Workshop.AccountsApi.Authorization
{
    public class PersonAuthorizationHandler : AuthorizationHandler<PersonRequirement, IResolverContext>
    {
        protected override Task HandleRequirementAsync
        (
            AuthorizationHandlerContext context,
            PersonRequirement requirement,
            IResolverContext resource
        )
        {
            var person = resource.Parent<Person>();

            var idClaim = context.User.Claims.FirstOrDefault(c => c.Type == "userId");

            if (idClaim != null)
            {
                if (person.Id.ToString() == idClaim.Value)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            
            var claim = new Claim("scope", "accounts.api");
            
            if (context.User.HasClaim(c => c.Value == claim.Value))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}