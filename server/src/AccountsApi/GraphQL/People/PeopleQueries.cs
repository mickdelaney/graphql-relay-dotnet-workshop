using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using Workshop.AccountsApi.Database;
using Workshop.AccountsApi.Domain;
using Workshop.AccountsApi.GraphQL.Core;

namespace Workshop.AccountsApi.GraphQL.People
{
    public class PeopleQueries
    {
        [GraphQLName("people")]
        public IQueryable<Person> GetPeople
        (
            [ScopedService] 
            AccountsDbContext context,
            IResolverContext resource
        )
        {
            var user = resource.ContextData["User"];
            return context.People;
        }
       
        public Task<Person> GetPersonByIdAsync
        (
            [ID(nameof(Person))]
            int id,
            PersonByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => dataLoader.LoadAsync(id, cancellationToken);
        
        public async Task<IEnumerable<Person>> GetPeopleByIdAsync
        (
            [ID(nameof(Person))]int[] ids,
            PersonByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => await dataLoader.LoadAsync(ids, cancellationToken);

        [UseAccountsDbContext]
        public Task<Person> GetPersonByDbIdAsync
        (
            int id,
            [ScopedService] 
            AccountsDbContext context,
            CancellationToken cancellationToken
        )
        {
            return context.People.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}