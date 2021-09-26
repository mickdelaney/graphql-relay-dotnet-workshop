using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Workshop.Core.GraphQL.Persistence
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<TDbContext>
        (
            this IObjectFieldDescriptor descriptor
        )
            where TDbContext : DbContext
        {
            return descriptor.UseScopedService
            (
                create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(),
                disposeAsync: (s, c) => c.DisposeAsync()
            );
        }
    }
}