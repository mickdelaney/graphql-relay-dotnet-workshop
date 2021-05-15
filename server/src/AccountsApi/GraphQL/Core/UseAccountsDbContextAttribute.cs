using System.Reflection;
using Core;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using NextGen.AccountsApi.Database;

namespace NextGen.AccountsApi.GraphQL.Core
{
    public class UseAccountsDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure
        (
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member
        )
        {
            descriptor.UseDbContext<AccountsDbContext>();
        }
    }
}