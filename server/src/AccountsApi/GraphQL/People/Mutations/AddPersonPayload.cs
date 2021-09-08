using HotChocolate.Types.Pagination;
using Workshop.AccountsApi.Domain;

namespace Workshop.AccountsApi.GraphQL.People.Mutations
{
    public class AddPersonPayload
    {
        public string ClientMutationId { get; }
        public Edge<Person> Person { get; }
        
        public AddPersonPayload(Edge<Person> person, string clientMutationId)
        {
            Person = person;
            ClientMutationId = clientMutationId;
        }
    }
}