using System;
using ContentApi.Domain;

namespace ContentApi.GraphQL
{
    public class Query
    {
        public ContentItem GetContentItem() => new 
        (
            id: 1,
            ownerId: 1,
            name: "Details On The X-Wing"
        );
    }
}
