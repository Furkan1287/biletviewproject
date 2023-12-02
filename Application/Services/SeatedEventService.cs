using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;

namespace Application.Services
{
    public interface ISeatedEventService
    {
        public Task<ICommandResult> CreateEventAsync(SeatedEventCreateDto eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(SeatedEvent eventItem);
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
        #region crud operations
        public async Task<ICommandResult> CreateEventAsync(SeatedEventCreateDto eventItem)
        {
            var entity = _mapper.Map<SeatedEvent>(eventItem);
            
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
        #endregion
    }
}
