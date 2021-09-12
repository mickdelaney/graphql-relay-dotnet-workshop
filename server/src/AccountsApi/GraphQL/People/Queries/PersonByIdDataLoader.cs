using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using Workshop.Accounts.Api.Database;
using Workshop.Accounts.Api.Domain;

namespace Workshop.Accounts.Api.GraphQL.People.Queries
{
    public class PersonByIdDataLoader : BatchDataLoader<PersonId, Person>
    {
        readonly IDbContextFactory<AccountsDbContext> _dbContextFactory;

        public PersonByIdDataLoader
        (       
            IBatchScheduler batchScheduler, 
            IDbContextFactory<AccountsDbContext> dbContextFactory
        ) 
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? 
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<PersonId, Person>> LoadBatchAsync
        (
            IReadOnlyList<PersonId> keys, 
            CancellationToken cancellationToken
        )
        {
            await using AccountsDbContext dbContext = _dbContextFactory.CreateDbContext();
             
            return await dbContext.People
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}