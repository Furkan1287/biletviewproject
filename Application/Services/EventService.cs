using Domain;
using Domain.Entities;
using Shared.Repository;

namespace Application.Services
{
    public interface IEventService
    {
        public Task<CommandResult<IEnumerable<Event>>> GetEvents();
    }
    public class EventService : IEventService
    {
        private readonly IGenericRepositoryAsync<Event> _eventRepository;

        public EventService(IGenericRepositoryAsync<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<CommandResult<IEnumerable<Event>>> GetEvents()
        {
            var data = await _eventRepository.GetAllAsync();
            return new SuccessCommandResult<IEnumerable<Event>>(data);
        }
    }
}
