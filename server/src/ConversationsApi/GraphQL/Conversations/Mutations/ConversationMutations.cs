using System.Security;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Workshop.Conversations.Api.Db;
using Workshop.Conversations.Api.Domain.Conversations;
using Workshop.Conversations.Api.GraphQL.Core;
using Workshop.Core.Domain;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ConversationMutations
    {
        [UseConversationsContext]
        public async Task<AddConversationPayload> StartConversationAsync
        (
            StartConversationInput input,
            [ScopedService] 
            ConversationsContext context,
            IResolverContext resource
        )
        {
            var user = resource.ContextData["User"] as IUser;

            if (user == null)
            {
                throw new SecurityException("User Is Not Authenticated");
            }
            
            var conversation = new Conversation
            {
                Id = ConversationIds.Generate(),
                Title = input.Title,
                Description = input.Description,
                AccountId = user.AccountId
            };
            
            conversation.Init(user);

            context.Conversations.Add(conversation);
            
            await context.SaveChangesAsync();

            var edge = new Edge<Conversation>(conversation, conversation.Id.ToString());
            
            return new AddConversationPayload(edge, input.ClientMutationId);
        }
    }
}