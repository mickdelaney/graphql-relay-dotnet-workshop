using HotChocolate.Types.Pagination;
using NextGen.AccountsApi.Domain;

namespace NextGen.AccountsApi.GraphQL.People
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