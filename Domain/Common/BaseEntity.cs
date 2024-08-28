namespace Domain.Common;

public abstract class BaseEntity<TEntityId>
{
    public TEntityId Id { get; protected set; }
}