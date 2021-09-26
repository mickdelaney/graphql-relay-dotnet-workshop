using System;

namespace Workshop.Core.Domain
{
    public static class AccountIds
    {
        public static AccountId Generate()
        {
            return new AccountId(Guid.NewGuid());
        }
    };
}