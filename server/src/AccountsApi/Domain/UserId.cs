using StronglyTypedIds;

namespace Workshop.Accounts.Api.Domain
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)] 
    public partial struct PersonId { }
}