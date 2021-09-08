using HotChocolate.Data.Filters;
using Workshop.AccountsApi.Domain;

namespace Workshop.AccountsApi.GraphQL.People.Types
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