using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Workshop.Conversations.Api.Models
{
    public record ConversationId(Guid Value)
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