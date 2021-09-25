using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workshop.Conversations.Api.Domain.Groups;

namespace Workshop.Conversations.Api.Domain.Threads
{
    public static class ThreadIds
    {
        public static ThreadId Generate()
        {
            return new ThreadId(Guid.NewGuid());
        }
        
        public static ValueConverter Converter => new ValueConverter<ThreadId, Guid>
        (
            v => v.Value,
            v => new ThreadId(v)
        );
    };
}