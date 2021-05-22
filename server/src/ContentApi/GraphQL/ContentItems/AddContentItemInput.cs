namespace ContentApi.GraphQL.ContentItems
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