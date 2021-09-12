using HotChocolate.Types;
using Workshop.Conversations.Api.GraphQL.Conversations.Queries;
using Workshop.Conversations.Api.Models;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Types
{
    public class ConversationType : ObjectType<Conversation>
    {
        protected override void Configure(IObjectTypeDescriptor<Conversation> descriptor)
        {
            descriptor.Authorize("conversation");
            
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<ConversationByIdDataLoader>().LoadAsync(id, ctx.RequestAborted))
                .Authorize("people");

            descriptor
                .Field(f => f.Title)
                .Type<NonNullType<StringType>>();
            
            descriptor
                .Field(f => f.Description)
                .Type<NonNullType<StringType>>();
            
            descriptor
                .Field(f => f.AccountId)
                .Resolve(f => f.Parent<Conversation>().AccountId)
                .Type<NonNullType<UuidType>>();
        }
    }
}