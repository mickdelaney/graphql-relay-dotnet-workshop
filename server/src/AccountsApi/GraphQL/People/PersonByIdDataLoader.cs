using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using NextGen.AccountsApi.Database;
using NextGen.AccountsApi.Domain;

namespace NextGen.AccountsApi.GraphQL.People
{
    public class PersonByIdDataLoader : BatchDataLoader<int, Person>
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

        protected override async Task<IReadOnlyDictionary<int, Person>> LoadBatchAsync
        (
            IReadOnlyList<int> keys, 
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