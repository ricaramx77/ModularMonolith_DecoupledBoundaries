using ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents
{
    public class InvoiceSentEvent : IDomainEvent
    {
        public int InvoiceId { get; init; }

        public int CustomerId { get; init; }

        public decimal Amount { get; init; }        
    }
}
