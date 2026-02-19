/*using ModularMonolith_DecoupledBoundaries.Services;

namespace ModularMonolith_DecoupledBoundaries.DomainEvents.Handlers
{
    public class UserInactiveEventHandler : IDomainEventHandler<UserInactiveEvent>
    {
        private readonly UserService _users;

        public UserInactiveEventHandler(UserService users)
        {
            _users = users;
        }

        public Task Handle(UserInactiveEvent @event)
        {
            _users.Deactivate(@event.UserId);
            return Task.CompletedTask;
        }
    }
}*/
