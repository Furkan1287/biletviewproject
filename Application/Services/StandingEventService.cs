using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;

namespace Application.Services
{
    public interface IStandingEventService
    {
        public Task<ICommandResult> CreateEventAsync(StandingEventCreateDto eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(StandingEvent eventItem);
    }

    public class StandingEventService : IStandingEventService
    {
        private readonly IGenericRepositoryAsync<StandingEvent> _standingEventRepository;
        readonly IMapper _mapper;

        public StandingEventService(IGenericRepositoryAsync<StandingEvent> standingEventRepository, IMapper mapper)
        {
            _standingEventRepository = standingEventRepository;
            _mapper = mapper;
        }
        #region crud operations
        public async Task<ICommandResult> CreateEventAsync(StandingEventCreateDto eventItem)
        {
            var entity = _mapper.Map<StandingEvent>(eventItem);

            if (eventItem.IsFree)
            {
                entity.Price = null;
            }
            await _standingEventRepository.AddAsync(entity);
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
        #endregion
    }
}
