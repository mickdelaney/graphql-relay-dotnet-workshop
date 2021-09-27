using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Db;
using Workshop.Conversations.Api.Domain.Conversations;
using Workshop.Tests.Config;
using Workshop.Tests.Fixtures;
using Xunit;

namespace Workshop.Tests.Conversations.Database
{
    public class ConversationDatabaseIntegrationTests : IClassFixture<DatabaseFixture>
    {
        readonly DatabaseFixture _fixture;

        public ConversationDatabaseIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Can_store_conversations()
        {
            var factory = _fixture.Resolve<IDbContextFactory<ConversationsContext>>();
            
            await using var db = factory.CreateDbContext();

            var conversations = db.GetConversations(TestDataConfig.TestAccountId, cancellationToken: CancellationToken.None);
        }
    }
}