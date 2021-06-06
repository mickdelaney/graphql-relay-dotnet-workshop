using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using Workshop.ContentApi.Database;
using Workshop.ContentApi.Domain;
using Workshop.ContentApi.GraphQL.Core;

namespace Workshop.ContentApi.GraphQL.ContentItems
{
    [ExtendObjectType(Name = "Mutation")]
    public class ContentItemMutations
    {
        [UseContentDbContext]
        public async Task<AddContentItemPayload> AddContentItemAsync
        (
            AddContentItemInput input,
            [ScopedService] 
            ContentDbContext context
        )
        {
            var contentType = await context.ContentTypes.Where(ct => ct.Id == input.ContentTypeId).FirstOrDefaultAsync();

            var contentItem = new ContentItem
            (
                name: input.Name,
                ownerId: input.OwnerId,
                tag: input.Tag
            )
            {
                ContentType = contentType
            };

            context.ContentItems.Add(contentItem);
            
            await context.SaveChangesAsync();

            var edge = new Edge<ContentItem>(contentItem, contentItem.Id.ToString());
            
            return new AddContentItemPayload(edge, input.ClientMutationId);
        }
    }
}