using ModularMonolith_DecoupledBoundaries.DomainEvents;
using ModularMonolith_DecoupledBoundaries.NotificationModule;

namespace ModularMonolith_DecoupledBoundaries.Services
{
    public class UserService : IDomainEventHandler<UserInactiveEvent>
    {
        private readonly NotificationsDbContext _db;

        public UserService(NotificationsDbContext db)
        {
            _db = db;
        }

        public Task Handle(UserInactiveEvent @event)
        {
            _db.Logs.Add(new NotificationLog
            {
                Message = $"User {@event.UserId} was deactivated"
            });
            //_db.SaveChanges();
            return Task.CompletedTask;
        }

        public void Deactivate(int userId)
        {
            _db.Logs.Add(new NotificationLog
            {
                Message = $"User {userId} deactivated manually"
            });
           // _db.SaveChanges();
        }
    }
}
