using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("default", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            services.AddHttpClient(Config.WellKnownSchemaNames.Accounts,
                c => c.BaseAddress = new Uri("http://localhost:5700/graphql"));
            services.AddHttpClient(Config.WellKnownSchemaNames.Content, 
                c => c.BaseAddress = new Uri("http://localhost:5701/graphql"));

            services
                .AddRouting()
                .AddGraphQLServer()
                .AddRemoteSchema(Config.WellKnownSchemaNames.Accounts)
                .AddRemoteSchema(Config.WellKnownSchemaNames.Content);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("default");

            app.UseEndpoints(endpoints =>
            {
                // By default the GraphQL server is mapped to /graphql
                // This route also provides you with our GraphQL IDE. In order to configure the
                // the GraphQL IDE use endpoints.MapGraphQL().WithToolOptions(...).
                endpoints.MapGraphQL();
            });
        }
    }
}
