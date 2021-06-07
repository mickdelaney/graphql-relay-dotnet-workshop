using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.AccountsApi.Authorization
{
    public class PeopleAuthorizationService
    {
        public Task<bool> HasAccess(IReadOnlyList<int> peopleIds)
        {
            return Task.FromResult(true);
        }
    }
}