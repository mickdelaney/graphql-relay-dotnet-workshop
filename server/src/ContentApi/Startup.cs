using ContentApi.GraphQL;
using Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace ContentApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(ConnectionMultiplexer.Connect("elevate.redis.local:6379"))
                .AddRouting()
                .AddGraphQLServer()
                .AddQueryType<Query>()
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
