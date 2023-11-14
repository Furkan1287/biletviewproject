using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IEventService
    {
        public Task CreateEvent(Event eventItem);
        public Task DeleteEvent(Guid id);
        public Task UpdateEvent(Event eventItem);
        public Task<Event> GetEventById(Guid id);
        public Task<List<Event>> GetEvents();
    }
}
