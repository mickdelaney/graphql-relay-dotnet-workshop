using ContentApi.Domain;
using HotChocolate.Types.Pagination;

namespace ContentApi.GraphQL.ContentTypes
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