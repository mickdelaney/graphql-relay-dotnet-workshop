using HotChocolate.Types;
using Workshop.Accounts.Api.Domain;
using Workshop.Accounts.Api.GraphQL.People.Queries;

namespace Workshop.Accounts.Api.GraphQL.People.Types
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.Authorize("person");
            
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<PersonByIdDataLoader>().LoadAsync(id, ctx.RequestAborted))
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