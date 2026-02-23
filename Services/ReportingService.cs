using ModularMonolith_DecoupledBoundaries.BillingModule;
using ModularMonolith_DecoupledBoundaries.DomainEvents;

namespace ModularMonolith_DecoupledBoundaries.Services
{
    public class ReportingService : IDomainEventHandler<MonthEndedEvent>
    {
        private readonly BillingDbContext _db;

        public ReportingService(BillingDbContext db)
        {
            _db = db;
        }

        public Task Handle(MonthEndedEvent @event) 
        {
            var invoices = _db.Invoices.ToList();
            
            //Generar la lógica del reporte
            return Task.CompletedTask;
        }

        public string GenerateMonthlyReport(Object endDate)
        {
            var total = _db.Invoices.Sum(i => i.Amount);
            return $"Monthly report generated. Total billed: {total} until {endDate}";
        }      
    }
}
