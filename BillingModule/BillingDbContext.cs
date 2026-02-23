using Microsoft.EntityFrameworkCore;

namespace ModularMonolith_DecoupledBoundaries.BillingModule
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }
    }    
}
