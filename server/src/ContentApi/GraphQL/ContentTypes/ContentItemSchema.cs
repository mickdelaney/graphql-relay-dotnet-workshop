using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Content.Api.GraphQL.ContentTypes.Mutations;
using Workshop.Content.Api.GraphQL.ContentTypes.Queries;
using Workshop.Content.Api.GraphQL.ContentTypes.Types;

namespace Workshop.Content.Api.GraphQL.ContentTypes
{
    public static class ContentTypesSchema
    {
        public static IRequestExecutorBuilder AddContentTypesSchema(this IRequestExecutorBuilder builder)
        {
            builder
                .AddType<ContentTypeObjectType>()
                .AddTypeExtension<ContentTypeQueries>()
                .AddTypeExtension<ContentTypeMutations>()
                .AddDataLoader<ContentTypeByIdDataLoader>();

            return builder;
        }
    }
}