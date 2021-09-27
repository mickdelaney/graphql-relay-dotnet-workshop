using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Core.EF;

namespace Workshop.Conversations.Api.Db
{
    public static class ConversationsContextInstaller
    {
        public static IServiceCollection AddIntegrationsDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextFactory<ConversationsContext>(options => ConfigureIntegrationsDatabase(options, config));
            services.AddDbContext<ConversationsContext>(options => ConfigureIntegrationsDatabase(options, config));

            DiagnosticListener.AllListeners.Subscribe(new DiagnosticObserver());
            
            return services;
        }
        
        static void ConfigureIntegrationsDatabase(DbContextOptionsBuilder options, IConfiguration config)
        {
            options.UseNpgsql(config.GetConnectionString("PostgresIntegrationsDatabase"))
                .EnableSensitiveDataLogging()
                .UseSnakeCaseNamingConvention()
                .LogTo(Console.WriteLine);
        }
    }
}