using HotChocolate.Types;
using Workshop.Conversations.Api.Db;
using Workshop.Conversations.Api.GraphQL.Conversations.Queries;
using Workshop.Core.HotChocolate;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Types
{
    public class ConversationQueriesType : ObjectTypeExtension<ConversationQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<ConversationQueries> descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);
            descriptor
                .Field(f => f.GetConversations(default!, default!))
                .Type<ListType<NonNullType<ConversationType>>>()
                .UseDbContext<ConversationsContext>()
                .UsePaging()
                .UseFiltering<ConversationFilterType>()
                .UseSorting();
        }
    }
}