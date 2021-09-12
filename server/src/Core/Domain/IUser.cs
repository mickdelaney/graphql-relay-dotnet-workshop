namespace Workshop.Core.Domain
{
    public interface IUser
    {
        AccountId AccountId { get; set; }
        UserId Id { get; set; }
    }
}