using Domain;
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
        public Task<ICommandResult> CreateEventAsync(Event eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(Event eventItem);
        public Task<ICommandResult<Event>> GetEventByIdAsync(Guid id);
        public Task<ICommandResult<IEnumerable<Event>>> GetEventsAsync();
    }
}
