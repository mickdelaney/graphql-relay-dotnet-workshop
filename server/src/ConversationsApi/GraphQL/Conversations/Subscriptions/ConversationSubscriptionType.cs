using HotChocolate.Types;
using Workshop.Conversations.Api.GraphQL.Conversations.Types;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Subscriptions
{
    public class ConversationSubscriptionType : ObjectType<ConversationSubscription>
    {
        protected override void Configure(IObjectTypeDescriptor<ConversationSubscription> descriptor)
        {
            descriptor.Field(t => t.OnStartConversation(default, default))
                .Type<NonNullType<ConversationType>>()
                .Argument("episode", arg => arg.Type<NonNullType<ConversationType>>());
        }
    }
}