using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workshop.Core.Domain;

namespace Workshop.Conversations.Api.Domain.Conversations
{
    public class ConversationAdministration
    {
        static JsonSerializerOptions _options = new();
        
        public IList<UserId> Administrators { get; set; }

        public ConversationAdministration()
        {
            Administrators = new List<UserId>();
        }
        
        
        public static ValueConverter Converter => new ValueConverter<ConversationAdministration, string>
        (
            v => JsonSerializer.Serialize(v, _options),
            v => Deserialize(v)
        );

        static ConversationAdministration Deserialize(string v)
        {
            if (string.IsNullOrWhiteSpace(v))
            {
                return new ConversationAdministration();
            }
        
            var deserialized = JsonSerializer.Deserialize<ConversationAdministration>(v, _options);
            if (deserialized == null)
            {
                return new ConversationAdministration();   
            } 
            
            return deserialized;
        }
    }
}