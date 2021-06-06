using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Workshop.ContentApi.Database;
using Workshop.ContentApi.Domain;
using Workshop.ContentApi.GraphQL.Core;

namespace Workshop.ContentApi.GraphQL.ContentTypes
{
    [ExtendObjectType(Name = "Mutation")]
    public class ContentTypeMutations
    {
        [UseContentDbContext]
        public async Task<AddContentTypePayload> AddContentTypeAsync
        (
            AddContentTypeInput input,
            [ScopedService] 
            ContentDbContext context
        )
        {
            var contentType = new ContentType
            (
               name: input.Name,
               ownerId: input.OwnerId
            );

            context.ContentTypes.Add(contentType);
            
            await context.SaveChangesAsync();

            var edge = new Edge<ContentType>(contentType, contentType.Id.ToString());
            
            return new AddContentTypePayload(edge, input.ClientMutationId);
        }
    }
}