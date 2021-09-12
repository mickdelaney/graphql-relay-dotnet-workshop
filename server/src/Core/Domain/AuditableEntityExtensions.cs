using NodaTime;

namespace Workshop.Core.Domain
{
    public static class AuditableEntityExtensions 
    {
        public static void Init(this IAuditableEntity entity, IUser user)
        {
            entity.AccountId = user.AccountId;
            entity.CreatedOn = new Instant();
            entity.CreatedById = user.Id;
            entity.Updated(user);
        }
        
        public static void Updated(this IAuditableEntity entity, IUser user)
        {
            entity.UpdatedOn = new Instant();
            entity.UpdatedById = user.Id;
        }
    }
}