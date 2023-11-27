using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Shared.Repository;

namespace Application.Services
{
    public interface IStandingEventService
    {
        public Task<ICommandResult> CreateEventAsync(List<IFormFile>? files, StandingEventCreateDto eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(StandingEvent eventItem);
        public Task<ICommandResult<StandingEvent>> GetEventByIdAsync(Guid id);
        public Task<ICommandResult<IEnumerable<StandingEvent>>> GetEventsAsync();
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

        public async Task<ICommandResult> CreateEventAsync(List<IFormFile>? files, StandingEventCreateDto eventItem)
        {
            var entity = _mapper.Map<StandingEvent>(eventItem);

            if (files?.Count > 0)
            {
                var images = new List<byte[]>();

                foreach (var file in files)
                {
                    images.Add(Shared.Helper.ImageHelper.ImageToByteArray(file));
                }
                entity.Images = images;
            }
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
