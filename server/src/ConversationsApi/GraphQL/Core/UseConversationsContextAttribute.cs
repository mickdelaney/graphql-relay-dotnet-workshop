using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Workshop.Conversations.Api.Db;
using Workshop.Core.HotChocolate;

namespace Workshop.Conversations.Api.GraphQL.Core
{
    public class UseConversationsContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure
        (
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member
        )
        {
            descriptor.UseDbContext<ConversationsContext>();
        }
    }
}