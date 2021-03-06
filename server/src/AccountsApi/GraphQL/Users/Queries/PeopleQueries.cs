using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using Workshop.Accounts.Api.Database;
using Workshop.Accounts.Api.Domain;
using Workshop.Accounts.Api.GraphQL.Core;

namespace Workshop.Accounts.Api.GraphQL.Users.Queries
{
    public class PeopleQueries
    {
        [GraphQLName("people")]
        public IQueryable<User> GetPeople
        (
            [ScopedService] 
            AccountsDbContext context,
            IResolverContext resource
        )
        {
            var user = resource.ContextData["User"];
            return context.People;
        }
       
        public Task<User> GetPersonByIdAsync
        (
            [ID(nameof(User))]
            UserId id,
            UserByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => dataLoader.LoadAsync(id, cancellationToken);
        
        public async Task<IEnumerable<User>> GetPeopleByIdAsync
        (
            [ID(nameof(User))]UserId[] ids,
            UserByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => await dataLoader.LoadAsync(ids, cancellationToken);

        [UseAccountsDbContext]
        public Task<User> GetPersonByDbIdAsync
        (
            UserId id,
            [ScopedService] 
            AccountsDbContext context,
            CancellationToken cancellationToken
        )
        {
            return context.People.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}