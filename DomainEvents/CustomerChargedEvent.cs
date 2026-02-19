

using ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents
{
    public class CustomerChargedEvent : IDomainEvent 
    {
        public int CustomerId { get; init; }
        public decimal Amount { get; init; }
    }
}
