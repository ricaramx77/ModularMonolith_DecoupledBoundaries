using Microsoft.AspNetCore.Components;
using ModularMonolith_DecoupledBoundaries.Data;
using ModularMonolith_DecoupledBoundaries.DomainEvents;

namespace ModularMonolith_DecoupledBoundaries.Services
{
    public class NotificationService : IDomainEventHandler<CustomerChargedEvent>, 
                                       IDomainEventHandler<InvoiceSentEvent>                                       
    {
        private readonly NotificationsDbContext _db;

        public NotificationService(NotificationsDbContext db)
        {
            _db = db;
        }

        public Task Handle(CustomerChargedEvent @event)
        {            
            Send(@event.CustomerId, $"CustomerX {@event.CustomerId} was charged {@event.Amount}");
            // _db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(InvoiceSentEvent @event)
        {           
            Send(@event.CustomerId, $"InvoiceX {@event.InvoiceId} was sent with amount {@event.Amount}");

            return Task.CompletedTask;
        }

        private void Send(int customerId, string message)
        {
            _db.Logs.Add(new NotificationLog
            {
                Message = message
            });
            //_db.SaveChanges();            
        }
    }
}
