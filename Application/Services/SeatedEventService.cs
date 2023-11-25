using Domain;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;

namespace Application.Services
{
    public interface ISeatedEventService
    {
        public Task<ICommandResult> CreateEventAsync(SeatedEventRequestDto eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(SeatedEvent eventItem);
        public Task<ICommandResult<SeatedEvent>> GetEventByIdAsync(Guid id);
        public Task<ICommandResult<IEnumerable<SeatedEvent>>> GetEventsAsync();
    }

    public class SeatedEventService : ISeatedEventService
    {
        readonly IGenericRepositoryAsync<SeatedEvent> _seatedEventRepository;

        public SeatedEventService(IGenericRepositoryAsync<SeatedEvent> seatedEventRepository)
        {
            _seatedEventRepository = seatedEventRepository;
        }

        public async Task<ICommandResult> CreateEventAsync(SeatedEventRequestDto eventItem)
        {
            var entity = new SeatedEvent
            {
                CategoryId = eventItem.CategoryId,
                OrganizerId = eventItem.OrganizerId,
                VenueId = eventItem.VenueId,
                Name = eventItem.Name,
                Description = eventItem.Description,
                StartDate = eventItem.StartDate,
                EndDate = eventItem.EndDate,
                IsFree = eventItem.IsFree,
                TicketCount = eventItem.TicketCount,
                Seats = eventItem.Seats,
                Images = eventItem.Images
            };
            await _seatedEventRepository.AddAsync(entity);
            return new SuccessCommandResult();
        }

        public async Task<ICommandResult> DeleteEventAsync(Guid id)
        {
            var deleteEvent = await _seatedEventRepository.GetAsync(e => e.Id == id);
            if (deleteEvent != null)
            {
                await _seatedEventRepository.DeleteAsync(deleteEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<SeatedEvent>> GetEventByIdAsync(Guid id)
        {
            var existEvent = await _seatedEventRepository.GetAsync(e => e.Id == id);
            if (existEvent != null)
            {
                return new SuccessCommandResult<SeatedEvent>(existEvent);
            }
            return new ErrorCommandResult<SeatedEvent>();
        }

        public async Task<ICommandResult<IEnumerable<SeatedEvent>>> GetEventsAsync()
        {
            var eventList = await _seatedEventRepository.GetAllAsync();
            return new SuccessCommandResult<IEnumerable<SeatedEvent>>(eventList);
        }

        public async Task<ICommandResult> UpdateEventAsync(SeatedEvent eventItem)
        {
            var existEvent = await _seatedEventRepository.GetAsync(e => e.Id == eventItem.Id);
            if (existEvent != null)
            {
                await _seatedEventRepository.UpdateAsync(existEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
    }
}
