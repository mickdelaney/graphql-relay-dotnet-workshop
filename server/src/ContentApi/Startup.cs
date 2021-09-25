using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Workshop.Content.Api.Database;
using Workshop.Content.Api.GraphQL.ContentItems;
using Workshop.Content.Api.GraphQL.ContentTypes;
using Workshop.Core.Config;
using Workshop.Core.HotChocolate;

namespace Workshop.Content.Api
{
    public class Startup
    {
        IWebHostEnvironment Environment { get; }

        IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ContentDbContext>(options => 
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
                
                
                
                .AddTypeExtension<ContentItemQueries>()
                .AddTypeExtension<ContentTypeQueries>()
                .AddTypeExtension<ContentItemMutations>()
                .AddTypeExtension<ContentTypeMutations>()
                .AddType<ContentItemObjectType>()
                .AddType<ContentTypeObjectType>()
                .AddDataLoader<ContentItemByIdDataLoader>()
                .AddDataLoader<ContentTypeByIdDataLoader>()
                
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
          
            // TryRunMigrations(app);
        }
        
        void TryRunMigrations(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ContentDbContext>();
                db.Database.MigrateAsync();
            }
        }
    }
}
