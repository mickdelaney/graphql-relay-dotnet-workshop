using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Workshop.Conversations.Api.Domain.Conversations
{
    public static class ConversationIds
    {
        public static ConversationId Generate()
        {
            return new ConversationId(Guid.NewGuid());
        }
        
        public static ValueConverter Converter => new ValueConverter<ConversationId, Guid>
        (
            v => v.Value,
            v => new ConversationId(v)
        );
    };
}