using HotChocolate.Types.Pagination;
using Workshop.ContentApi.Domain;

namespace Workshop.ContentApi.GraphQL.ContentItems
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