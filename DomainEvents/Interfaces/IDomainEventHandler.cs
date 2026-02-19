using ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents
{
    public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        Task Handle(TEvent @event);
    }
}
