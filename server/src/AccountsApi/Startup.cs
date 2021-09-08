using System;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using Workshop.AccountsApi.Authorization;
using Workshop.AccountsApi.Database;
using Workshop.AccountsApi.Domain;
using Workshop.AccountsApi.GraphQL.People;
using Workshop.AccountsApi.GraphQL.People.Mutations;
using Workshop.AccountsApi.GraphQL.People.Queries;
using Workshop.AccountsApi.GraphQL.People.Types;
using Workshop.Core;
using Workshop.Core.Config;
using Workshop.Core.HotChocolate;

namespace Workshop.AccountsApi
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
            services.AddPooledDbContextFactory<AccountsDbContext>(options => 
                options.UseNpgsql(WorkshopConfig.PostgresConnectionString)
            );
            
            // services.AddDbContext<AccountsDbContext>(options => 
            //     options.UseNpgsql(WorkshopConfig.PostgresConnectionString)
            // , ServiceLifetime.Transient);
                
            services.AddControllers();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5703";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddSingleton<IAuthorizationHandler, PeopleAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, PersonAuthorizationHandler>();
            
            services.AddSingleton<PeopleAuthorizationService>();
                
            services.AddAuthorization(options =>
            {
                options.AddPolicy("people", policy => policy.Requirements.Add(new PeopleRequirement()));
                options.AddPolicy("person", policy => policy.Requirements.Add(new PersonRequirement()));
                
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "accounts.api");
                });
            });
            
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = WorkshopConfig.RedisConnectionString;
            });
            
            services
                .AddSingleton(_ => ConnectionMultiplexer.Connect(WorkshopConfig.RedisConnectionString))
                .AddRouting()
                .AddGraphQLServer()
                .AddHttpRequestInterceptor<UserContextInterceptor>()
                .AddQueryType(d => d.Name("Query"))
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<PeopleMutations>()
                .AddType<PersonType>()
                .AddType<PersonFilterType>()
                .AddType<PeopleQueriesType>()
                .BindRuntimeType<Person, PersonFilterType>()
                .AddSorting()
                .AddFiltering()
                .EnableRelaySupport()
                .AddAuthorization()
                .AddDataLoader<PersonByIdDataLoader>()
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
                    .SetName("Accounts")
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
            
            app.UseCors("default");

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization("ApiScope");
                endpoints.MapGraphQL();
            });
            
            // TryRunMigrations(app);
        }
        
        void TryRunMigrations(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AccountsDbContext>();
                db.Database.MigrateAsync();
            }
        }
    }
}
