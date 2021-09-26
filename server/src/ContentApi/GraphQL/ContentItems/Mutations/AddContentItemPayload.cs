using HotChocolate.Types.Pagination;
using Workshop.Content.Api.Domain;

namespace Workshop.Content.Api.GraphQL.ContentItems.Mutations
{
    public class AddContentItemPayload
    {
        public string ClientMutationId { get; }
        public Edge<ContentItem> ContentItem { get; }
        
        public AddContentItemPayload(Edge<ContentItem> contentItem, string clientMutationId)
        {
            ContentItem = contentItem;
            ClientMutationId = clientMutationId;
        }
    }
}