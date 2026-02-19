/*using ModularMonolith_DecoupledBoundaries.Services;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents.Handlers
{
    public class CustomerChargedEventHandler : IDomainEventHandler<CustomerChargedEvent>
    {
        private readonly NotificationService _notifications;

        public CustomerChargedEventHandler(NotificationService notifications)
        {
            _notifications = notifications;
        }

        public Task Handle(CustomerChargedEvent @event)
        {
            // Delegate to NotificationService
            _notifications.Send(@event.CustomerId, $"You were charged {@event.Amount}");
            return Task.CompletedTask;
        }
    }
}*/
