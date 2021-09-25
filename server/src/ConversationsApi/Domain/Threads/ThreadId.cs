using StronglyTypedIds;

namespace Workshop.Conversations.Api.Domain.Threads
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)] 
    public partial struct ThreadId { }
}