using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Conversations.Api.GraphQL.Conversations.Mutations;
using Workshop.Conversations.Api.GraphQL.Conversations.Queries;
using Workshop.Conversations.Api.GraphQL.Conversations.Types;

namespace Workshop.Conversations.Api.GraphQL.Conversations
{
    public static class ConversationsSchema
    {
        public static IRequestExecutorBuilder AddConversationsSchema(this IRequestExecutorBuilder builder)
        {
            builder
                .AddType<ConversationType>()
                .AddType<ConversationQueriesType>()
                .AddType<ConversationFilterType>()
                .AddTypeExtension<ConversationQueries>()
                .AddTypeExtension<ConversationMutations>()
                .AddDataLoader<ConversationByIdDataLoader>();

            return builder;
        }
    }
}