using HotChocolate.Types.Pagination;
using Workshop.Conversations.Api.Domain.Conversations;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Mutations
{
    public class AddConversationPayload
    {
        public string ClientMutationId { get; }
        public Edge<Conversation> Conversation { get; }
        
        public AddConversationPayload(Edge<Conversation> conversation, string clientMutationId)
        {
            Conversation = conversation;
            ClientMutationId = clientMutationId;
        }
    }
}