using ContentApi.Database;
using ContentApi.Domain;
using ContentApi.GraphQL.ContentItems;
using ContentApi.GraphQL.ContentTypes;
using Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace ContentApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ContentDbContext>(options => 
                options.UseSqlite("Data Source=content.db")
            );
            
            services
                .AddSingleton(ConnectionMultiplexer.Connect("localhost:6379"))
                .AddRouting()
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<ContentItemQueries>()
                    .AddTypeExtension<ContentTypeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<ContentItemMutations>()
                    .AddTypeExtension<ContentTypeMutations>()
                .AddType<ContentItemObjectType>()
                .AddType<ContentTypeObjectType>()
                .AddDataLoader<ContentItemByIdDataLoader>()
                .AddDataLoader<ContentTypeByIdDataLoader>()
                .AddSorting()
                .AddFiltering()
                .EnableRelaySupport()
                .AddDiagnosticEventListener(sp =>
                {
                    return new ConsoleQueryLogger(sp.GetApplicationService<ILogger<ConsoleQueryLogger>>());
                })
                .AddDiagnosticEventListener(sp =>
                {
                    return new MiniProfilerQueryLogger();
                })
                .InitializeOnStartup()
                // We configure the publish definition
                .PublishSchemaDefinition
                (
                    c => c
                        // The name of the schema. This name should be unique
                        .SetName("Content")
                        .PublishToRedis
                        (
                            // The configuration name under which the schema should be published
                            "NextGen",
                            // The connection multiplexer that should be used for publishing
                            sp => sp.GetRequiredService<ConnectionMultiplexer>()
                        )
                );
            
            services.AddErrorFilter<GraphQLErrorFilter>();
            
            services.AddMiniProfiler(options => { options.RouteBasePath = "/profiler"; });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
