using HotChocolate.Types;
using Workshop.Accounts.Api.Database;
using Workshop.Accounts.Api.GraphQL.People.Queries;
using Workshop.Core.HotChocolate;

namespace Workshop.Accounts.Api.GraphQL.People.Types
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