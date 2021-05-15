using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using NextGen.AccountsApi.Database;
using NextGen.AccountsApi.Domain;
using NextGen.AccountsApi.GraphQL.Core;

namespace NextGen.AccountsApi.GraphQL.People
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