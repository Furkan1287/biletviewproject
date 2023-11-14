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
        private readonly IGenericRepositoryAsync<Event> _repository;

        public EventService(IGenericRepositoryAsync<Event> repository)
        {
            _repository = repository;
        }

        public async Task CreateEvent(Event eventItem)
        {
            await _repository.AddAsync(eventItem);
        }

        public async Task DeleteEvent(Guid id)
        {
            var deleteEvent = await _repository.GetAsync(e => e.Id == id);
            await _repository.DeleteAsync(deleteEvent);
        }

        public async Task<Event> GetEventById(Guid id)
        {
            return await _repository.GetAsync(e => e.Id == id);
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateEvent(Event eventItem)
        {
            await _repository.UpdateAsync(eventItem);
        }
    }
}
