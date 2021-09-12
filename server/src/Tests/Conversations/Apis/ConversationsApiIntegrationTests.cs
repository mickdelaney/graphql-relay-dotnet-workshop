using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Workshop.Conversations.Api;
using Xunit;

namespace Workshop.Tests.Conversations.Apis
{
    public class ConversationsApiIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly WebApplicationFactory<Startup> _factory;
 
        public ConversationsApiIntegrationTests()
        {
            _factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                // configure builder
            });
        }
 
        [Fact]
        public async Task Can_create_graphql()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/graphql");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            // use client to call the Web API
        }
    }
}