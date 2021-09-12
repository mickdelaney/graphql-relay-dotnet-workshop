using HotChocolate.Types;
using Workshop.Conversations.Api.GraphQL.Conversations.Types;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Subscriptions
{
    public class ConversationSubscription
    {
        public object? OnStartConversation(object o, object o1)
        {
            throw new System.NotImplementedException();
        }
    }
    
    
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