using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Workshop.Conversations.Api.Domain.Messages
{
    public static class MessageIds
    {
        public static MessageId Generate()
        {
            return new MessageId(Guid.NewGuid());
        }
        
        public static ValueConverter Converter => new ValueConverter<MessageId, Guid>
        (
            v => v.Value,
            v => new MessageId(v)
        );
    };
}