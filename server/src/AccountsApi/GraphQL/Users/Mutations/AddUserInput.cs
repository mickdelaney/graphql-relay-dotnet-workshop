namespace Workshop.Accounts.Api.GraphQL.Users.Mutations
{
    public record AddUserInput
    (
        string ClientMutationId,
        string Name,
        string? WebSite
    );
}