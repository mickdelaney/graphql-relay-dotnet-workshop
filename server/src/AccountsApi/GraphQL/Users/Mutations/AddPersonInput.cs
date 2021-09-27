namespace Workshop.Accounts.Api.GraphQL.Users.Mutations
{
    public record AddPersonInput
    (
        string ClientMutationId,
        string Name,
        string? WebSite
    );
}