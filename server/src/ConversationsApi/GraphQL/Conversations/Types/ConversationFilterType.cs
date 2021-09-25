using HotChocolate.Data.Filters;
using Workshop.Conversations.Api.Domain.Conversations;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Types
{
    public class ConversationFilterType : FilterInputType<Conversation>
    {
        protected override void Configure
        (
            IFilterInputTypeDescriptor<Conversation> descriptor
        )
        {
            descriptor.BindFieldsExplicitly();
            
            descriptor
                .Field(f => f.Id)
                .Type<BooleanOperationFilterInputType>();
            
            descriptor.Field(f => f.AccountId);
            descriptor.Field(f => f.Description);
        }
    }
}