using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Shared.Repository;

namespace Application.Services
{
    public interface ISeatedEventService
    {
        public Task<ICommandResult> CreateEventAsync(List<IFormFile>? files, SeatedEventCreateDto eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(SeatedEvent eventItem);
        public Task<ICommandResult<SeatedEvent>> GetEventByIdAsync(Guid id);
        public Task<ICommandResult<IEnumerable<SeatedEvent>>> GetEventsAsync();
    }

    public class SeatedEventService : ISeatedEventService
    {
        readonly IGenericRepositoryAsync<SeatedEvent> _seatedEventRepository;
        readonly IMapper _mapper;

        public SeatedEventService(IGenericRepositoryAsync<SeatedEvent> seatedEventRepository, IMapper mapper)
        {
            _seatedEventRepository = seatedEventRepository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> CreateEventAsync(List<IFormFile>? files, SeatedEventCreateDto eventItem)
        {
            var entity = _mapper.Map<SeatedEvent>(eventItem);

            if (files?.Count > 0)
            {
                var images = new List<byte[]>();

                foreach (var file in files)
                {
                    images.Add(Shared.Helper.ImageHelper.ImageToByteArray(file));
                }
                entity.Images = images;
            }
            
            if (!eventItem.IsFree)
            {
                var totalSeatCount = (eventItem.VIPSeatCount + eventItem.PremiumSeatCount + eventItem.DisabledSeatCount + eventItem.StudentSeatCount + eventItem.StandartSeatCount);
                if (totalSeatCount != eventItem.TicketCount)
                {
                    return new ErrorCommandResult("Bilet sayısı ile koltuk sayısı aynı olmalıdır.");
                }
                var seats = new List<Seat>();

                int[] seatCounts = {
                eventItem.VIPSeatCount,
                eventItem.PremiumSeatCount,
                eventItem.DisabledSeatCount,
                eventItem.StandartSeatCount,
                eventItem.StudentSeatCount
            };
                decimal?[] seatPrices = {
                eventItem.VIPSeatPrice,
                eventItem.PremiumSeatPrice,
                eventItem.DisabledSeatPrice,
                eventItem.StandartSeatPrice,
                eventItem.StudentSeatPrice
            };
                SeatType[] seatTypes = {
                    SeatType.VIP,
                    SeatType.Premium,
                    SeatType.Disabled,
                    SeatType.Standart,
                    SeatType.Student
                };

                int seatNumber = 1;

                for (int i = 0; i < seatCounts.Length; i++)
                {
                    for (int j = 1; j <= seatCounts[i]; j++)
                    {
                        seats.Add(new Seat()
                        {
                            SeatNumber = seatNumber++,
                            SeatType = seatTypes[i],
                            SeatPrice = seatPrices[i]
                        });
                    }
                }

                entity.Seats = seats;
            }

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
