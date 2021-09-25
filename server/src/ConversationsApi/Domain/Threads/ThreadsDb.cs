using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;

namespace Workshop.Conversations.Api.Domain.Threads
{
    public static class ThreadsDb
    {
        public static async Task<Option<Thread>> GetThreadById
        (
            this ConversationsContext dbContext, 
            ThreadId id
        )
        {
            var entity = await dbContext
                .Threads
                .AsQueryable()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return Option<Thread>.None;
            }
            
            return entity;
        }
    }
}