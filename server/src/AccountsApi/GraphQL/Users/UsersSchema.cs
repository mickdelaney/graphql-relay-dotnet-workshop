using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Accounts.Api.Authorization;
using Workshop.Accounts.Api.Domain;
using Workshop.Accounts.Api.GraphQL.People.Mutations;
using Workshop.Accounts.Api.GraphQL.People.Queries;
using Workshop.Accounts.Api.GraphQL.People.Types;

namespace Workshop.Accounts.Api.GraphQL.People
{
    public static class UserSchema
    {
        public static IRequestExecutorBuilder AddPeopleSchema
        (
            this IRequestExecutorBuilder builder,
            IServiceCollection services
        )
        {
            builder
                .AddTypeExtension<PeopleMutations>()
                .AddType<PersonType>()
                .AddType<PersonFilterType>()
                .AddType<PeopleQueriesType>()
                .BindRuntimeType<User, PersonFilterType>()
                .AddDataLoader<PersonByIdDataLoader>();

            services.AddSingleton<IAuthorizationHandler, PeopleAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, PersonAuthorizationHandler>();
            
            services.AddSingleton<PeopleAuthorizationService>();

            return builder;
        }
    }
}