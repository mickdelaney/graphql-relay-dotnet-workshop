using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Workshop.Core.GraphQL.Errors;
using Workshop.Core.GraphQL.Interceptors;
using Workshop.Core.GraphQL.Logging;

namespace Workshop.Core.GraphQL.Config
{
    public static class HotChocolateApiConfig
    {
        public static IRequestExecutorBuilder AddDefaultConfig
        (
            this IRequestExecutorBuilder builder,
            IServiceCollection services
        )
        {
            builder
                .AddHttpRequestInterceptor<UserContextInterceptor>()
                .AddQueryType(d => d.Name("Query"))
                .AddMutationType(d => d.Name("Mutation"))
                .AddSorting()
                .AddFiltering()
                .AddAuthorization()
                .AddGlobalObjectIdentification()
                .AddQueryFieldToMutationPayloads()
                .AddDiagnosticEventListener(sp =>
                {
                    return new ConsoleQueryLogger(sp.GetApplicationService<ILogger<ConsoleQueryLogger>>());
                })
                .AddDiagnosticEventListener(sp =>
                {
                    return new MiniProfilerQueryLogger();
                })
                .InitializeOnStartup();
 
            services.AddErrorFilter<GraphQLErrorFilter>();

            return builder;
        }
    }
}