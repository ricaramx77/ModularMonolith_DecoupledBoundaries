using ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents
{
    public class UserInactiveEvent : IDomainEvent
    {
        public int UserId { get; init; }
    }
}
