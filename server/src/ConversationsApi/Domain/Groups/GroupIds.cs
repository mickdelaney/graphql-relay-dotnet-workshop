using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Workshop.Conversations.Api.Domain.Groups
{
    public static class GroupIds
    {
        public static GroupId Generate()
        {
            return new GroupId(Guid.NewGuid());
        }
        
        public static ValueConverter Converter => new ValueConverter<GroupId, Guid>
        (
            v => v.Value,
            v => new GroupId(v)
        );
    };
}