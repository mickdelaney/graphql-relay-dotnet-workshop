using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Workshop.Accounts.Api.Database;
using Workshop.Core.Config;

namespace Cli
{
    public class Startup
    {
        public IHostEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            HostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<AccountsDbContext>(options =>
            {
                options.UseNpgsql(WorkshopConfig.PostgresConnectionString);
                options.LogTo(Console.WriteLine);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
        }
    }
}