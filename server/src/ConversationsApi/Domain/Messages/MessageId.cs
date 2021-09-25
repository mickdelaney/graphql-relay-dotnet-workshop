using StronglyTypedIds;

namespace Workshop.Conversations.Api.Domain.Messages
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)] 
    public partial struct MessageId { }
}