using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;
using Workshop.Core.Domain;

namespace Workshop.Conversations.Api.Domain.Conversations
{
    public static class ConversationsDb
    {
        public static async Task<IReadOnlyList<Conversation>> GetConversations
        (
            this ConversationsContext dbContext, 
            AccountId accountId,
            CancellationToken cancellationToken
        )
        {
            return await dbContext
                .Conversations
                .AsQueryable()
                .Where(t => t.AccountId == accountId)
                .ToListAsync(cancellationToken);
        }
        
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