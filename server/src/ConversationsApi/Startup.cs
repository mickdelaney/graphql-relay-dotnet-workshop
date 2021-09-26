using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Workshop.Conversations.Api.Db;
using Workshop.Conversations.Api.GraphQL.Conversations;
using Workshop.Core.Config;
using Workshop.Core.GraphQL.Config;

namespace Workshop.Conversations.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ConversationsContext>(options => 
                options.UseNpgsql(WorkshopConfig.PostgresConnectionString)
            );
            //
            // services.AddDbContext<ContentDbContext>(options => 
            //     options.UseNpgsql(WorkshopConfig.PostgresConnectionString)
            // , ServiceLifetime.Transient);
            
            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = WorkshopConfig.RedisConnectionString;
            });
            
            services
                .AddSingleton(_ => ConnectionMultiplexer.Connect(WorkshopConfig.RedisConnectionString))
                .AddRouting()
                .AddGraphQLServer()
                    .AddDefaultConfig(services)
                    .AddConversationsSchema()
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
           
            services.AddMiniProfiler(options => { options.RouteBasePath = "/profiler"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
