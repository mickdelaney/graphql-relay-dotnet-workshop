using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Accounts.Api.Authorization;
using Workshop.Accounts.Api.Domain;
using Workshop.Accounts.Api.GraphQL.Users.Mutations;
using Workshop.Accounts.Api.GraphQL.Users.Queries;
using Workshop.Accounts.Api.GraphQL.Users.Types;

namespace Workshop.Accounts.Api.GraphQL.Users
{
    public static class UsersSchema
    {
        public static IRequestExecutorBuilder AddPeopleSchema
        (
            this IRequestExecutorBuilder builder,
            IServiceCollection services
        )
        {
            builder
                .AddTypeExtension<UserMutations>()
                .AddType<UserType>()
                .AddType<UserFilterType>()
                .AddType<UserQueriesType>()
                .BindRuntimeType<User, UserFilterType>()
                .AddDataLoader<UserByIdDataLoader>();

            services.AddSingleton<IAuthorizationHandler, UsersAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, UserAuthorizationHandler>();
            
            services.AddSingleton<UserAuthorizationService>();

            return builder;
        }
    }
}