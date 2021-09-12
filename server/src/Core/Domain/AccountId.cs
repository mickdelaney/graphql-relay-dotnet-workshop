using System;

namespace Workshop.Core.Domain
{
    public record AccountId(Guid Value)
    {
        public static AccountId Generate()
        {
            return new AccountId(Guid.NewGuid());
        }
    };
}