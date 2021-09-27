using HotChocolate.Types.Pagination;
using Workshop.Accounts.Api.Domain;

namespace Workshop.Accounts.Api.GraphQL.Users.Mutations
{
    public class AddPersonPayload
    {
        public string ClientMutationId { get; }
        public Edge<User> Person { get; }
        
        public AddPersonPayload(Edge<User> person, string clientMutationId)
        {
            Person = person;
            ClientMutationId = clientMutationId;
        }
    }
}