using Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NextGen.AccountsApi.Database;
using NextGen.AccountsApi.GraphQL;
using NextGen.AccountsApi.GraphQL.People;

namespace NextGen.AccountsApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AccountsDbContext>(options => 
                options.UseSqlite("Data Source=accounts.db")
            );
            
            services
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
                .AddDataLoader<PersonByIdDataLoader>()
                .AddDiagnosticEventListener(sp =>
                {
                    return new ConsoleQueryLogger(sp.GetApplicationService<ILogger<ConsoleQueryLogger>>());
                })
                .AddDiagnosticEventListener(sp =>
                {
                    return new MiniProfilerQueryLogger();
                });
            
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
