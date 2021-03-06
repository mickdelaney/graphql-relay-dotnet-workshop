using HotChocolate.Types;
using Workshop.Conversations.Api.Domain.Conversations;
using Workshop.Conversations.Api.GraphQL.Conversations.Queries;

namespace Workshop.Conversations.Api.GraphQL.Conversations.Types
{
    public class ConversationType : ObjectType<Conversation>
    {
        public const string GraphName = "Conversation";
        
        protected override void Configure(IObjectTypeDescriptor<Conversation> descriptor)
        {
            descriptor.Name(GraphName);

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