using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Workshop.ContentApi.Database;
using Workshop.ContentApi.Domain;
using Workshop.ContentApi.GraphQL.Core;

namespace Workshop.ContentApi.GraphQL.ContentItems
{
    [ExtendObjectType(Name = "Query")]
    public class ContentItemQueries
    {
        [UseContentDbContext]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentItem> GetContentItem
        (
            [ScopedService] 
            ContentDbContext context
        )
        {
            return context.ContentItems;
        }
       
        public Task<ContentItem> GetContentItemByIdAsync
        (
            [ID(nameof(ContentItem))]
            int id,
            ContentItemByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => dataLoader.LoadAsync(id, cancellationToken);
        
        public async Task<IEnumerable<ContentItem>> GetContentItemByIdAsync
        (
            [ID(nameof(ContentItem))]int[] ids,
            ContentItemByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => await dataLoader.LoadAsync(ids, cancellationToken);
    }
}