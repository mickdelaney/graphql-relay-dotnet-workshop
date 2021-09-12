using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;
using Workshop.Conversations.Api.GraphQL.Core;
using Workshop.Conversations.Api.Models;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Queries
{
    public class ConversationQueries
    {
        [GraphQLName("conversations")]
        public IQueryable<Conversation> GetConversations
        (
            [ScopedService] 
            ConversationsContext context,
            IResolverContext resource
        )
        {
            var user = resource.ContextData["User"];
            return context.Conversations;
        }
       
        public Task<Conversation> GetConversationByIdAsync
        (
            [ID(nameof(Conversation))]
            ConversationId id,
            ConversationByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => dataLoader.LoadAsync(id, cancellationToken);
        
        public async Task<IEnumerable<Conversation>> GetConversationByIdAsync
        (
            [ID(nameof(Conversation))]ConversationId[] ids,
            ConversationByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => await dataLoader.LoadAsync(ids, cancellationToken);

        [UseConversationsContext]
        public Task<Conversation> GetConversationByDbIdAsync
        (
            ConversationId id,
            [ScopedService] 
            ConversationsContext context,
            CancellationToken cancellationToken
        )
        {
            return context.Conversations.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}