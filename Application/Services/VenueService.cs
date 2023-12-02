using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;

namespace Application.Services
{
    public interface IVenueService
    {
        Task<ICommandResult> CreateVenueAsync(VenueCreateDto venueCreateDto);
        Task<ICommandResult> DeleteVenueAsync(Guid id);
        Task<ICommandResult> UpdateVenueAsync(Venue venueItem);
        Task<ICommandResult<VenueDetailDto>> GetVenueByIdAsync(Guid id);
        Task<ICommandResult<IEnumerable<VenueDetailDto>>> GetVenuesAsync();
    }
    public class VenueService : IVenueService
    {
        readonly IGenericRepositoryAsync<Venue> _venueRepository;
        readonly IMapper _mapper;

        public VenueService(IGenericRepositoryAsync<Venue> venueRepository, IMapper mapper)
        {
            _venueRepository = venueRepository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> CreateVenueAsync(VenueCreateDto venueCreateDto)
        {
            var entity = _mapper.Map<Venue>(venueCreateDto);
            await _venueRepository.AddAsync(entity);
            return new SuccessCommandResult("Venue successfully created.");
        }

        public async Task<ICommandResult> DeleteVenueAsync(Guid id)
        {
            var existItem = await _venueRepository.GetAsync(v => v.Id == id);
            if (existItem != null)
            {
                await _venueRepository.DeleteAsync(existItem);
                return new SuccessCommandResult("Venue successsfully deleted.");
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<VenueDetailDto>> GetVenueByIdAsync(Guid id)
        {
            var existItem = await _venueRepository.GetAsync(e => e.Id == id);
            if (existItem != null)
            {
                var data = _mapper.Map<VenueDetailDto>(existItem);
                return new SuccessCommandResult<VenueDetailDto>(data);
            }
            return new ErrorCommandResult<VenueDetailDto>();
        }

        public async Task<ICommandResult<IEnumerable<VenueDetailDto>>> GetVenuesAsync()
        {
            var itemList = await _venueRepository.GetAllAsync();

            var data = new List<VenueDetailDto>();
            foreach (var item in itemList)
            {
                var entity = _mapper.Map<VenueDetailDto>(item);
                data.Add(entity);
            }
            return new SuccessCommandResult<IEnumerable<VenueDetailDto>>(data);
        }

        public async Task<ICommandResult> UpdateVenueAsync(Venue venueItem)
        {
            var existItem = await _venueRepository.GetAsync(e => e.Id == venueItem.Id);
            if (existItem != null)
            {
                await _venueRepository.UpdateAsync(existItem);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
    }
}
