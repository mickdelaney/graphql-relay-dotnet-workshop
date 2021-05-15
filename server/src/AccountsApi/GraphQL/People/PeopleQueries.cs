using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using NextGen.AccountsApi.Database;
using NextGen.AccountsApi.Domain;
using NextGen.AccountsApi.GraphQL.Core;

namespace NextGen.AccountsApi.GraphQL.People
{
    [ExtendObjectType(Name = "Query")]
    public class PeopleQueries
    {
        [UseAccountsDbContext]
        [UseSorting]
        [UsePaging]
        public IQueryable<Person> GetPeople
        (
            [ScopedService] 
            AccountsDbContext context
        )
        {
            return context.People;
        }
       
        public Task<Person> GetPersonByIdAsync
        (
            [ID(nameof(Person))]
            int id,
            PersonByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => dataLoader.LoadAsync(id, cancellationToken);
        
        public async Task<IEnumerable<Person>> GetPersonByIdAsync
        (
            [ID(nameof(Person))]int[] ids,
            PersonByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => await dataLoader.LoadAsync(ids, cancellationToken);
    }
}