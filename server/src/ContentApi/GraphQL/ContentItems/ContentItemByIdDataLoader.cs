using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContentApi.Database;
using ContentApi.Domain;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace ContentApi.GraphQL.ContentItems
{
    public class ContentItemByIdDataLoader : BatchDataLoader<int, ContentItem>
    {
        readonly IDbContextFactory<ContentDbContext> _dbContextFactory;

        public ContentItemByIdDataLoader
        (       
            IBatchScheduler batchScheduler, 
            IDbContextFactory<ContentDbContext> dbContextFactory
        ) 
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? 
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, ContentItem>> LoadBatchAsync
        (
            IReadOnlyList<int> keys, 
            CancellationToken cancellationToken
        )
        {
            await using ContentDbContext dbContext = _dbContextFactory.CreateDbContext();
             
            return await dbContext.ContentItems
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}