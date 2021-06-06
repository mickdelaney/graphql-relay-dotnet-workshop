using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Workshop.ContentApi.Database;
using Workshop.Core;

namespace Workshop.ContentApi.GraphQL.Core
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