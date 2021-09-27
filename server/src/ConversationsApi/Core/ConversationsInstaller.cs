using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Conversations.Api.Db;

namespace Workshop.Conversations.Api.Core
{
    public static class ConversationsInstaller
    {
        public static IServiceCollection AddConversations
        (
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddIntegrationsDbContext(config);
            
            return services;
        }
    }
}