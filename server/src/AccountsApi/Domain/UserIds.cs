using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Workshop.Accounts.Api.Domain
{
    public static class UserIds
    {
        public static UserId Generate()
        {
            return new UserId(Guid.NewGuid());
        }
        
        public static ValueConverter Converter => new ValueConverter<UserId, Guid>
        (
            v => v.Value,
            v => new UserId(v)
        );
    };
}