using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Workshop.Conversations.Api;
using Xunit;

namespace Workshop.Tests.Conversations.Apis
{
    public class ConversationsApiConversationQueryTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _client;

        public ConversationsApiConversationQueryTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }
    }
}