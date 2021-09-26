using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Types;
using Workshop.Core.Domain;

namespace Workshop.Core.GraphQL.Config
{
    public static class EntityConfig
    {
        public static void AddAuditableFields<T>(this IObjectTypeDescriptor<T> descriptor) where T : IAuditableEntity
        {
            descriptor
                .Field(f => f.CreatedOn)
                .Type<NonNullType<DateTimeType>>();

            descriptor
                .Field(f => f.CreatedById)
                .Type<NonNullType<UuidType>>();
            
            descriptor
                .Field(f => f.UpdatedOn)
                .Type<NonNullType<DateTimeType>>();

            descriptor
                .Field(f => f.UpdatedById)
                .Type<NonNullType<UuidType>>();
        }
        
        
        public static void AddEntityFilters<T, TId>(this IFilterInputTypeDescriptor<T> descriptor) where T : IEntity<TId>
        {
            descriptor.Field(f => f.Id);
        }
        
        public static void AddAuditableSorts<T>(this ISortInputTypeDescriptor<T> descriptor) where T : IAuditableEntity
        {
            descriptor.Field(f => f.CreatedOn).Name("CreatedOn");
            descriptor.Field(f => f.UpdatedOn).Name("UpdatedOn");
        }
    }
}