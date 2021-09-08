using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Workshop.AccountsApi.Database;
using Workshop.Core;
using Workshop.Core.HotChocolate;

namespace Workshop.AccountsApi.GraphQL.Core
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