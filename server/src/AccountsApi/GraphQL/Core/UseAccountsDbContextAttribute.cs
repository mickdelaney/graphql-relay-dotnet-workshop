using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Workshop.Accounts.Api.Database;
using Workshop.Core.GraphQL.Persistence;

namespace Workshop.Accounts.Api.GraphQL.Core
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