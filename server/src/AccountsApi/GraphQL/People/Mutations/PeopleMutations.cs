using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Workshop.Accounts.Api.Database;
using Workshop.Accounts.Api.Domain;
using Workshop.Accounts.Api.GraphQL.Core;

namespace Workshop.Accounts.Api.GraphQL.People.Mutations
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