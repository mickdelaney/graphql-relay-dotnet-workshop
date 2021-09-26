namespace Workshop.Content.Api.GraphQL.ContentTypes.Mutations
{
    public record AddContentTypeInput
    (
        string ClientMutationId,
        string Name,
        int OwnerId
    );
}