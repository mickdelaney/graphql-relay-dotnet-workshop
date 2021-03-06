namespace Workshop.Content.Api.GraphQL.ContentItems.Mutations
{
    public record AddContentItemInput
    (
        string ClientMutationId,
        string Name,
        int OwnerId,
        int ContentTypeId,
        string Tag
    );
}