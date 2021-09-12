using NodaTime;

namespace Workshop.Core.Domain
{
    public interface IAuditableEntity
    {
        AccountId AccountId { get; set; }
        Instant CreatedOn { get; set; }
        UserId CreatedById { get; set; }
        Instant UpdatedOn { get; set; }
        UserId UpdatedById { get; set; }
    }
}