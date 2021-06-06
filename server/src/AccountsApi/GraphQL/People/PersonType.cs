using HotChocolate.Resolvers;
using HotChocolate.Types;
using Workshop.AccountsApi.Domain;

namespace Workshop.AccountsApi.GraphQL.People
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<PersonByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
            descriptor
                .Field(f => f.WebSite)
                .Type<StringType>()
                .Authorize();
        }
    }
}