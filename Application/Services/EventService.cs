using Domain;
using Domain.Entities;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly IGenericRepositoryAsync<Event> _eventRepository;

        public EventService(IGenericRepositoryAsync<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ICommandResult> CreateEventAsync(Event eventItem)
        {
            await _eventRepository.AddAsync(eventItem);
            return new SuccessCommandResult();
        }

        public async Task<ICommandResult> DeleteEventAsync(Guid id)
        {
            var deleteEvent = await _eventRepository.GetAsync(e => e.Id == id);
            if (deleteEvent != null)
            {
                await _eventRepository.DeleteAsync(deleteEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<Event>> GetEventByIdAsync(Guid id)
        {
            var existEvent = await _eventRepository.GetAsync(e => e.Id == id);
            if (existEvent != null)
            {
                return new SuccessCommandResult<Event>(existEvent);
            }
            return new ErrorCommandResult<Event>(); 
        }

        public async Task<ICommandResult<IEnumerable<Event>>> GetEventsAsync()
        {
            var eventList = await _eventRepository.GetAllAsync();
            return new SuccessCommandResult<IEnumerable<Event>>(eventList);
        }

        public async Task<ICommandResult> UpdateEventAsync(Event eventItem)
        {
            var existEvent = await _eventRepository.GetAsync(e => e.Id == eventItem.Id);
            if (existEvent != null)
            {
                await _eventRepository.UpdateAsync(existEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
    }
}
