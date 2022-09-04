using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Workshop.Accounts.Api.Database;
using Workshop.Accounts.Api.Domain;
using Workshop.Accounts.Api.GraphQL.Core;

namespace Workshop.Accounts.Api.GraphQL.Users.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class UserMutations
    {
        [UseAccountsDbContext]
        public async Task<UserPayload> AddPersonAsync
        (
            AddUserInput input,
            [ScopedService] 
            AccountsDbContext context
        )
        {
            var person = new User
            {
                Name = input.Name,
                WebSite = input.WebSite
            };

            context.People.Add(person);
            
            await context.SaveChangesAsync();

            var edge = new Edge<User>(person, person.Id.ToString());
            return new UserPayload(edge, input.ClientMutationId);
        }
    }
}