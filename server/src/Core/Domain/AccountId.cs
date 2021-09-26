using StronglyTypedIds;

namespace Workshop.Core.Domain
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)] 
    public partial struct AccountId { }
}