namespace Workshop.ContentApi.GraphQL.ContentTypes
{
    public record AddContentTypeInput
    (
        string ClientMutationId,
        string Name,
        int OwnerId
    );
}