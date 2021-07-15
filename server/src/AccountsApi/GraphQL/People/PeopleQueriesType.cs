using HotChocolate.Types;
using Workshop.AccountsApi.Database;
using Workshop.Core.Hotchocolate;

namespace Workshop.AccountsApi.GraphQL.People
{
    public class PeopleQueriesType : ObjectTypeExtension<PeopleQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<PeopleQueries> descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);
            descriptor
                .Field(f => f.GetPeople(default, default))
                .Type<ListType<NonNullType<PersonType>>>()
                .UseDbContext<AccountsDbContext>()
                .UsePaging()
                .UseFiltering<PersonFilterType>()
                .UseSorting();
        }
    }
}