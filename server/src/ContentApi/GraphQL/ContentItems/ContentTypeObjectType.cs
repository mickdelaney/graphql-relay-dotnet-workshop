using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Workshop.Content.Api.Database;
using Workshop.Content.Api.Domain;
using Workshop.Core.HotChocolate;

namespace Workshop.Content.Api.GraphQL.ContentItems
{
    public class ContentItemObjectType : ObjectType<ContentItem>
    {
        protected override void Configure(IObjectTypeDescriptor<ContentItem> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<ContentItemByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(f => f.OwnerId)
                .Type<IntType>();
            
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
            
            descriptor
                .Field(f => f.Tag)
                .Type<StringType>();
            
            descriptor
                .Field(t => t.ContentType)
                .ResolveWith<ContentItemResolvers>(t => t.GetContentTypeAsync(default!, default!, default))
                .UseDbContext<ContentDbContext>();
        }
        
        private class ContentItemResolvers
        {
            public async Task<ContentType> GetContentTypeAsync
            (
                ContentItem contentItem,
                [ScopedService] 
                ContentDbContext dbContext,
                CancellationToken cancellationToken)
            {
                var contentType = await dbContext.ContentTypes
                    .Where(s => s.Id == contentItem.ContentTypeId)
                    .FirstOrDefaultAsync(cancellationToken);

                return contentType;
            }
        }
    }
}