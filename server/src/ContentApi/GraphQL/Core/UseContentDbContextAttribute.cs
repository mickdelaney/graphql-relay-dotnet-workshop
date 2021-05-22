using System.Reflection;
using ContentApi.Database;
using Core;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace ContentApi.GraphQL.Core
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