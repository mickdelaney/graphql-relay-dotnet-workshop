namespace Workshop.AccountsApi.GraphQL.People.Mutations
{
    public record AddPersonInput
    (
        string ClientMutationId,
        string Name,
        string? WebSite
    );
}