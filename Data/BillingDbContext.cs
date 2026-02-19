using Microsoft.EntityFrameworkCore;

namespace ModularMonolith_DecoupledBoundaries.Data
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }
    }

    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool Sent { get; internal set; }
    }
}
