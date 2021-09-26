using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Workshop.Content.Api.Database;
using Workshop.Core.GraphQL.Persistence;

namespace Workshop.Content.Api.GraphQL.Core
{
    public class UseContentDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure
        (
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member
        )
        {
            descriptor.UseDbContext<ContentDbContext>();
        }
    }
}