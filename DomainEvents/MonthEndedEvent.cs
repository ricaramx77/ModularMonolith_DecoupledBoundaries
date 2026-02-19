using ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents
{
    public class MonthEndedEvent : IDomainEvent
    {
        public object EndDate { get; internal set; }
    }
}
