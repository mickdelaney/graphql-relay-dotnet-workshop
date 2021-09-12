using System;

namespace Workshop.Core.Domain
{
    public record UserId(Guid Value)
    {
        public static UserId Generate()
        {
            return new UserId(Guid.NewGuid());
        }
    };
}