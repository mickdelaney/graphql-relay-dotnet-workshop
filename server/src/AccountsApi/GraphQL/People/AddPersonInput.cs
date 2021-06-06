namespace Workshop.AccountsApi.GraphQL.People
{
    public record AddPersonInput
    (
        string ClientMutationId,
        string Name,
        string? WebSite
    );
}