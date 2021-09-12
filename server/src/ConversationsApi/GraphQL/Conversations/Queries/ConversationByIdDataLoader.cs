using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;
using Workshop.Conversations.Api.Models;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Queries
{
    public class ConversationByIdDataLoader : BatchDataLoader<ConversationId, Conversation>
    {
        readonly IDbContextFactory<ConversationsContext> _dbContextFactory;

        public ConversationByIdDataLoader
        (       
            IBatchScheduler batchScheduler, 
            IDbContextFactory<ConversationsContext> dbContextFactory
        ) 
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? 
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<ConversationId, Conversation>> LoadBatchAsync
        (
            IReadOnlyList<ConversationId> keys, 
            CancellationToken cancellationToken
        )
        {
            await using ConversationsContext dbContext = _dbContextFactory.CreateDbContext();
             
            return await dbContext.Conversations
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}