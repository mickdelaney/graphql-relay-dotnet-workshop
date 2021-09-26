using HotChocolate.Types;
using Workshop.Content.Api.Domain;
using Workshop.Content.Api.GraphQL.ContentTypes.Queries;

namespace Workshop.Content.Api.GraphQL.ContentTypes.Types
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