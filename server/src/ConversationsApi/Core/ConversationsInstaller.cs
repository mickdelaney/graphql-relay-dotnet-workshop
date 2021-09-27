using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Workshop.Conversations.Api.Core
{
    public static class ConversationsPersistenceInstaller
    {
        public static IServiceCollection AddIntegrationsDbContext
        (
            this IServiceCollection services,
            IConfiguration config
        )
        {
            
        }
    }
}