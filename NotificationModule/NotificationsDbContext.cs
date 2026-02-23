using Microsoft.EntityFrameworkCore;

namespace ModularMonolith_DecoupledBoundaries.NotificationModule
{
    public class NotificationsDbContext : DbContext
    {
        public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options) : base(options) { }

        public DbSet<NotificationLog> Logs { get; set; }
    }

    public class NotificationLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }

}
