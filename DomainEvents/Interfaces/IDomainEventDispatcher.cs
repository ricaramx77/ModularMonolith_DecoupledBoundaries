namespace ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    }
}
