using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Workshop.AccountsApi.Database;
using Workshop.AccountsApi.Domain;
using Workshop.AccountsApi.GraphQL.Core;

namespace Workshop.AccountsApi.GraphQL.People
{
    [ExtendObjectType(Name = "Mutation")]
    public class PeopleMutations
    {
        [UseAccountsDbContext]
        public async Task<AddPersonPayload> AddPersonAsync
        (
            AddPersonInput input,
            [ScopedService] 
            AccountsDbContext context
        )
        {
            var person = new Person
            {
                Name = input.Name,
                WebSite = input.WebSite
            };

            context.People.Add(person);
            
            await context.SaveChangesAsync();

            var edge = new Edge<Person>(person, person.Id.ToString());
            return new AddPersonPayload(edge, input.ClientMutationId);
        }
    }
}