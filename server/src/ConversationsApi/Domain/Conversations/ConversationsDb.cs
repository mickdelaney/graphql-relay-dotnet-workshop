using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;

namespace Workshop.Conversations.Api.Domain.Conversations
{
    public static class ConversationsDb
    {
        public static async Task<Option<Conversation>> GetConversationById
        (
            this ConversationsContext dbContext, 
            ConversationId id,
            CancellationToken cancellationToken
        )
        {
            var entity = await dbContext
                .Conversations
                .AsQueryable()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return Option<Conversation>.None;
            }
            
            return entity;
        }
    }
}