using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Workshop.Conversations.Api.Core;
using Workshop.Core.DB;
using Workshop.Core.Framework.Settings;

namespace Workshop.Tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        readonly IHost _host;
        
        public DatabaseFixture()
        {
            var host = new HostBuilder();

            host.ConfigureAppConfiguration((context, builder) =>
            {
                context.HostingEnvironment.EnvironmentName = "Testing";
                builder.AddSharedSettings(context);
            });
            
            host.ConfigureServices((context, services) =>
            {
                services.AddConversations(context.Configuration);
                services.AddConnectionStrings(context.Configuration, context.HostingEnvironment.ApplicationName);
            });
            
            _host = host.Build();
        }

        public void Dispose()
        {
            _host?.Dispose();
        }

        public IServiceProvider Services => _host.Services;
        
        public T Resolve<T>()
        {
            return _host.Services.GetRequiredService<T>();
        }
    }
}