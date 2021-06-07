using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Gateway
{
    public class Startup
    {
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

            services.AddHttpClient(Config.WellKnownSchemaNames.Accounts, (sp, client) =>
            {
                var logger = sp.GetRequiredService<ILogger<Startup>>();
                var context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    logger.LogInformation("Authorization Header Found & Forwarded");
                    
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse
                    (
                        context.Request.Headers["Authorization"].ToString()
                    );
                }
                else
                {
                    logger.LogWarning("No Authorization Header Found");
                }
                client.BaseAddress = new Uri("https://localhost:5700/graphql");
            });
            
            services.AddHttpClient(Config.WellKnownSchemaNames.Content, (sp, client) =>
            {
                var logger = sp.GetRequiredService<ILogger<Startup>>();
                var context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    logger.LogInformation("Authorization Header Found & Forwarded");
                    
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse
                    (
                        context.Request.Headers["Authorization"].ToString()
                    );
                }
                else
                {
                    logger.LogWarning("No Authorization Header Found");
                }
                client.BaseAddress = new Uri("https://localhost:5701/graphql");
            });

            services
                .AddHttpContextAccessor()
                .AddRouting()
                .AddSingleton(ConnectionMultiplexer.Connect("workshop.local:6379"))
                .AddGraphQLServer()
                .AddHttpRequestInterceptor<RequestInterceptor>()
                .AddRemoteSchemasFromRedis("NextGen", sp => sp.GetRequiredService<ConnectionMultiplexer>())
                .AddTypeExtensionsFromFile("./Stitching.graphql");
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
