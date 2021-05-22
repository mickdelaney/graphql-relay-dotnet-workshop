using ContentApi.Domain;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace ContentApi.GraphQL.ContentItems
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
        }
    }
}