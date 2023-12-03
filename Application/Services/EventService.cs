using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;
using System.Linq.Expressions;

namespace Application.Services
{
    public interface IEventService
    {
        Task<ICommandResult<IEnumerable<EventDetailDto>>> GetEvents();
        Task<ICommandResult<EventDetailDto>> GetEventById(Guid id);
        Task<ICommandResult<IEnumerable<EventDetailDto>>> GetPastEvents();
    }
    public class EventService : IEventService
    {
        private readonly IGenericRepositoryAsync<Event> _eventRepository;
        readonly IMapper _mapper;

        Expression<Func<Event, object>>[] includes = new Expression<Func<Event, object>>[]
        {
            s => s.Category,
            s => s.Organiser,
            s => s.Venue,
            s => s.Images
        };

        public EventService(IGenericRepositoryAsync<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<ICommandResult<IEnumerable<EventDetailDto>>> GetEvents()
        {
            var eventList = await _eventRepository.GetAllAsync(includes);
            var data = new List<EventDetailDto>();

            foreach (var item in eventList)
            {
                var entity = _mapper.Map<EventDetailDto>(item);
                data.Add(entity);
            }
            
            return new SuccessCommandResult<IEnumerable<EventDetailDto>>(data);
        }
        public async Task<ICommandResult<EventDetailDto>> GetEventById(Guid id)
        {
            var eventItem = await _eventRepository.GetAsync(e => e.Id == id, includes);
            if (eventItem == null)
            {
                return new ErrorCommandResult<EventDetailDto>();
            }
            eventItem.PopularityCount++;
            await _eventRepository.UpdateAsync(eventItem);
            var data = _mapper.Map<EventDetailDto>(eventItem);
            return new SuccessCommandResult<EventDetailDto>(data);
        }

        public async Task<ICommandResult<IEnumerable<EventDetailDto>>> GetEventsByDateRange(DateTime startDate, DateTime endDate)
        {
            var eventList = await _eventRepository.GetAllAsync(includes, e => e.StartDate >= startDate && e.EndDate <= endDate);
            var data = new List<EventDetailDto>();

            foreach (var item in eventList)
            {
                data.Add(_mapper.Map<EventDetailDto>(item));
            }

            return new SuccessCommandResult<IEnumerable<EventDetailDto>>(data);
        }
        public async Task<ICommandResult<IEnumerable<EventDetailDto>>> GetPastEvents()
        {
            var pastEvents = await _eventRepository.GetAllAsync(includes, e => e.EndDate < DateTime.UtcNow);

            var data = new List<EventDetailDto>();
            foreach (var item in pastEvents)
            {
                data.Add(_mapper.Map<EventDetailDto>(item));
            }

            return new SuccessCommandResult<IEnumerable<EventDetailDto>>(data);
        }

    }
}
