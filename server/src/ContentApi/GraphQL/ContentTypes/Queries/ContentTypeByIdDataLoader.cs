using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using Workshop.Content.Api.Database;
using Workshop.Content.Api.Domain;

namespace Workshop.Content.Api.GraphQL.ContentTypes.Queries
{
    public class ContentTypeByIdDataLoader : BatchDataLoader<int, ContentType>
    {
        readonly IDbContextFactory<ContentDbContext> _dbContextFactory;

        public ContentTypeByIdDataLoader
        (       
            IBatchScheduler batchScheduler, 
            IDbContextFactory<ContentDbContext> dbContextFactory
        ) 
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? 
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, ContentType>> LoadBatchAsync
        (
            IReadOnlyList<int> keys, 
            CancellationToken cancellationToken
        )
        {
            await using ContentDbContext dbContext = _dbContextFactory.CreateDbContext();
             
            return await dbContext.ContentTypes
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}