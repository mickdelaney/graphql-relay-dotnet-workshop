using HotChocolate.Types;
using Workshop.Accounts.Api.Domain;
using Workshop.Accounts.Api.GraphQL.Users.Queries;

namespace Workshop.Accounts.Api.GraphQL.Users.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Authorize("person");
            
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<UserByIdDataLoader>().LoadAsync(id, ctx.RequestAborted))
                .Authorize("people");

            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
            descriptor
                .Field(f => f.WebSite)
                .Type<StringType>();
        }
    }
}