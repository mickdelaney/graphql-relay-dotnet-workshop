using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;

namespace Workshop.Conversations.Api.Domain.Messages
{
    public static class MessagesDb
    {
        public static async Task<Option<Message>> GetMessageById
        (
            this ConversationsContext dbContext, 
            MessageId id
        )
        {
            var entity = await dbContext
                .Messages
                .AsQueryable()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return Option<Message>.None;
            }
            
            return entity;
        }
    }
}