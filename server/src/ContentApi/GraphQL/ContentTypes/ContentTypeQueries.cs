using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContentApi.Database;
using ContentApi.Domain;
using ContentApi.GraphQL.Core;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace ContentApi.GraphQL.ContentTypes
{
    [ExtendObjectType(Name = "Query")]
    public class ContentTypeQueries
    {
        [UseContentDbContext]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentType> GetContentType
        (
            [ScopedService] 
            ContentDbContext context
        )
        {
            return context.ContentTypes;
        }
       
        public Task<ContentType> GetContentTypeByIdAsync
        (
            [ID(nameof(ContentType))]
            int id,
            ContentTypeByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => dataLoader.LoadAsync(id, cancellationToken);
        
        public async Task<IEnumerable<ContentType>> GetContentTypeByIdAsync
        (
            [ID(nameof(ContentType))]int[] ids,
            ContentTypeByIdDataLoader dataLoader,
            CancellationToken cancellationToken
        ) => await dataLoader.LoadAsync(ids, cancellationToken);
    }
}