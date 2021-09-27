using HotChocolate.Types;
using Workshop.Accounts.Api.Database;
using Workshop.Accounts.Api.GraphQL.Users.Queries;
using Workshop.Core.GraphQL.Persistence;

namespace Workshop.Accounts.Api.GraphQL.Users.Types
{
    public class UserQueriesType : ObjectTypeExtension<PeopleQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<PeopleQueries> descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);
            descriptor
                .Field(f => f.GetPeople(default, default))
                .Type<ListType<NonNullType<UserType>>>()
                .UseDbContext<AccountsDbContext>()
                .UsePaging()
                .UseFiltering<UserFilterType>()
                .UseSorting();
        }
    }
}