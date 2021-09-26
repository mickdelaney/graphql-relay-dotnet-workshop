using System.Threading.Tasks;
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

            
        }
    }
}