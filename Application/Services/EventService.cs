using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;

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
        public async Task<CommandResult<IEnumerable<Event>>> GetEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            var events = await _eventRepository.GetAllAsync(e => e.StartDate >= startDate && e.EndDate <= endDate);

            return new SuccessCommandResult<IEnumerable<Event>>(events);
        }
        public async Task<CommandResult<IEnumerable<Event>>> GetPastEvents()
        {
            // Şu anki tarihe kadar olan etkinlikleri filtrele
            var pastEvents = await _eventRepository.GetAllAsync(e => e.EndDate < DateTime.UtcNow);

            return new SuccessCommandResult<IEnumerable<Event>>(pastEvents);
        }

    }
}
