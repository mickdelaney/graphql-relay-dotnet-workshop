namespace Workshop.Conversations.Api.GraphQL.Conversations.Mutations
{
    public record StartConversationInput
    (
        string ClientMutationId,
        string Title,
        string? Description
    );
}