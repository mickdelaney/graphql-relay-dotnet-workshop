using StronglyTypedIds;

namespace Workshop.Conversations.Api.Domain.Conversations
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)] 
    public partial struct ConversationId { }
}