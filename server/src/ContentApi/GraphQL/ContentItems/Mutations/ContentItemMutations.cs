using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using Workshop.Content.Api.Database;
using Workshop.Content.Api.Domain;
using Workshop.Content.Api.GraphQL.Core;

namespace Workshop.Content.Api.GraphQL.ContentItems.Mutations
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