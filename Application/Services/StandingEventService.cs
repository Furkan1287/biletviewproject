using Domain;
using Domain.Entities;
using Shared.Repository;

namespace Application.Services
{
    public interface IStandingEventService
    {
        public Task<ICommandResult> CreateEventAsync(StandingEvent eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(StandingEvent eventItem);
        public Task<ICommandResult<StandingEvent>> GetEventByIdAsync(Guid id);
        public Task<ICommandResult<IEnumerable<StandingEvent>>> GetEventsAsync();
    }

    public class StandingEventService : IStandingEventService
    {
        private readonly IGenericRepositoryAsync<StandingEvent> _standingEventRepository;

        public StandingEventService(IGenericRepositoryAsync<StandingEvent> standingEventRepository)
        {
            _standingEventRepository = standingEventRepository;
        }

        public async Task<ICommandResult> CreateEventAsync(StandingEvent eventItem)
        {
            await _standingEventRepository.AddAsync(eventItem);
            return new SuccessCommandResult();
        }

        public async Task<ICommandResult> DeleteEventAsync(Guid id)
        {
            var deleteEvent = await _standingEventRepository.GetAsync(e => e.Id == id);
            if (deleteEvent != null)
            {
                await _standingEventRepository.DeleteAsync(deleteEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<StandingEvent>> GetEventByIdAsync(Guid id)
        {
            var existEvent = await _standingEventRepository.GetAsync(e => e.Id == id);
            if (existEvent != null)
            {
                return new SuccessCommandResult<StandingEvent>(existEvent);
            }
            return new ErrorCommandResult<StandingEvent>(); 
        }

        public async Task<ICommandResult<IEnumerable<StandingEvent>>> GetEventsAsync()
        {
            var eventList = await _standingEventRepository.GetAllAsync();
            return new SuccessCommandResult<IEnumerable<StandingEvent>>(eventList);
        }

        public async Task<ICommandResult> UpdateEventAsync(StandingEvent eventItem)
        {
            var existEvent = await _standingEventRepository.GetAsync(e => e.Id == eventItem.Id);
            if (existEvent != null)
            {
                await _standingEventRepository.UpdateAsync(existEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
    }
}
