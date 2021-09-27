using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.Accounts.Api.Authorization
{
    public class UserAuthorizationService
    {
        public Task<bool> HasAccess(IReadOnlyList<int> peopleIds)
        {
            return Task.FromResult(true);
        }
    }
}