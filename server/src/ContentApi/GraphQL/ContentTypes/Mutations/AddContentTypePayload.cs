using HotChocolate.Types.Pagination;
using Workshop.Content.Api.Domain;

namespace Workshop.Content.Api.GraphQL.ContentTypes.Mutations
{
    public class AddContentTypePayload
    {
        public string ClientMutationId { get; }
        public Edge<ContentType> ContentType { get; }
        
        public AddContentTypePayload(Edge<ContentType> contentType, string clientMutationId)
        {
            ContentType = contentType;
            ClientMutationId = clientMutationId;
        }
    }
}