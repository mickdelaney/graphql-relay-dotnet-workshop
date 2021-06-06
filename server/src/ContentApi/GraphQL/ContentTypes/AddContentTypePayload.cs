using HotChocolate.Types.Pagination;
using Workshop.ContentApi.Domain;

namespace Workshop.ContentApi.GraphQL.ContentTypes
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