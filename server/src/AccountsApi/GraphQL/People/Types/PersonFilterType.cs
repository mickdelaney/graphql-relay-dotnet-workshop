using HotChocolate.Data.Filters;
using Workshop.Accounts.Api.Domain;

namespace Workshop.Accounts.Api.GraphQL.People.Types
{
    public class PersonFilterType : FilterInputType<Person>
    {
        protected override void Configure
        (
            IFilterInputTypeDescriptor<Person> descriptor
        )
        {
            descriptor.BindFieldsExplicitly();
            
            descriptor
                .Field(f => f.Id)
                .Type<BooleanOperationFilterInputType>();
            
            descriptor.Field(f => f.Name);
            descriptor.Field(f => f.WebSite);
        }
    }
}