/*using ModularMonolith_DecoupledBoundaries.Services;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents.Handlers
{
    public class MonthEndedEventHandler : IDomainEventHandler<MonthEndedEvent>
    {
        private readonly ReportingService _reporting;

        public MonthEndedEventHandler(ReportingService reporting)
        {
            _reporting = reporting;
        }

        public Task Handle(MonthEndedEvent @event)
        {
            _reporting.GenerateMonthlyReport(@event.EndDate);
            return Task.CompletedTask;
        }
    }
}*/
