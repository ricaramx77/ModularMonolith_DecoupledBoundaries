using ModularMonolith_DecoupledBoundaries.Data;
using ModularMonolith_DecoupledBoundaries.DomainEvents;
using ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces;

namespace ModularMonolith_DecoupledBoundaries.Services
{
    public class BillingService
    {
        private readonly BillingDbContext _db;
        private readonly IDomainEventDispatcher _dispatcher;

        public BillingService(BillingDbContext db, IDomainEventDispatcher dispatcher)
        {
            _db = db;
            _dispatcher = dispatcher;
        }

        public string ChargeCustomer(int customerId, decimal amount)
        {
            var invoice = new Invoice { Amount = amount };
            _db.Invoices.Add(invoice);
            //_db.SaveChanges();
            
            _dispatcher.Dispatch(new CustomerChargedEvent //logs or sends a notification.
            {
                CustomerId = customerId,
                Amount = amount
            });

            return $"Customer was charged successfully: {amount}";
        }       

        public string SendInvoice(int invoiceId)
        {
            var invoice = _db.Invoices.Find(invoiceId);
            if (invoice != null)
            {
                invoice.Sent = true;
                //_db.SaveChanges();

                _dispatcher.Dispatch(new InvoiceSentEvent //logs or sends a notification.
                {
                    InvoiceId = invoice.Id,
                    Amount = invoice.Amount
                });

                return $"Invoice sent successfully";
            }
            return $"Invoice not found";
        }
    }
}
