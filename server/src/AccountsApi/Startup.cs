using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using Workshop.AccountsApi.Database;
using Workshop.AccountsApi.GraphQL.People;
using Workshop.Core;

namespace Workshop.AccountsApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AccountsDbContext>(options => 
                options.UseSqlite("Data Source=accounts.db")
            );
            
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
            
            services.AddAuthorization(options =>
            {
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
            
            services
                .AddSingleton(ConnectionMultiplexer.Connect("localhost:6379"))
                .AddRouting()
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<PeopleQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<PeopleMutations>()
                .AddType<PersonType>()
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
        }
    }
}
