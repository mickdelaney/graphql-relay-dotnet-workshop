using StronglyTypedIds;

namespace Workshop.Conversations.Api.Domain.Groups
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)] 
    public partial struct GroupId { }
}