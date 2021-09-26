using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Content.Api.GraphQL.ContentItems.Mutations;
using Workshop.Content.Api.GraphQL.ContentItems.Queries;
using Workshop.Content.Api.GraphQL.ContentItems.Types;

namespace Workshop.Content.Api.GraphQL.ContentItems
{
    public static class ContentItemSchema
    {
        public static IRequestExecutorBuilder AddContentItemsSchema(this IRequestExecutorBuilder builder)
        {
            builder
                .AddType<ContentItemObjectType>()
                .AddTypeExtension<ContentItemQueries>()
                .AddTypeExtension<ContentItemMutations>()
                .AddDataLoader<ContentItemByIdDataLoader>();

            return builder;
        }
    }
}