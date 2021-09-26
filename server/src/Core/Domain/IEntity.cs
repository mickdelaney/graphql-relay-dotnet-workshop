namespace Workshop.Core.Domain
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}