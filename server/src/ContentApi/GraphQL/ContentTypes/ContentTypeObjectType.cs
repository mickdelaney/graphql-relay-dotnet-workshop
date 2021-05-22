using ContentApi.Domain;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace ContentApi.GraphQL.ContentTypes
{
    public class ContentTypeObjectType : ObjectType<ContentType>
    {
        protected override void Configure(IObjectTypeDescriptor<ContentType> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<ContentTypeByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(f => f.OwnerId)
                .Type<IntType>();
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
        }
    }
}