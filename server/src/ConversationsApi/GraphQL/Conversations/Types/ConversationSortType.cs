using HotChocolate.Data.Sorting;
using Workshop.Conversations.Api.Domain.Conversations;
using Workshop.Core.GraphQL.Config;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Types
{
    public class ConversationSortType : SortInputType<Conversation>
    {
        protected override void Configure(ISortInputTypeDescriptor<Conversation> descriptor)
        {
            descriptor.Name($"{ConversationType.GraphName}Sort");
            
            descriptor.BindFieldsExplicitly();
            
            descriptor.AddAuditableSorts();
        }
    }
}