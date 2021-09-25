using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;

namespace Workshop.Conversations.Api.Domain.Groups
{
    public static class GroupsDb
    {
        public static async Task<Option<Group>> GetGroupById
        (
            this ConversationsContext dbContext, 
            GroupId id
        )
        {
            var entity = await dbContext
                .Groups
                .AsQueryable()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return Option<Group>.None;
            }
            
            return entity;
        }
    }
}