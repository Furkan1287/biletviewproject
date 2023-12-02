using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;

namespace Application.Services
{
    public interface IOrganizerService
    {
        Task<ICommandResult> CreateOrganizerAsync(OrganizerCreateDto organizerCreateDto);
        Task<ICommandResult> DeleteOrganizerAsync(Guid id);
        Task<ICommandResult> UpdateOrganizerAsync(Organizer organizerItem);
        Task<ICommandResult<OrganizerDetailDto>> GetOrganizerByIdAsync(Guid id);
        Task<ICommandResult<IEnumerable<OrganizerDetailDto>>> GetOrganizersAsync();
    }
    public class OrganizerService : IOrganizerService
    {
        readonly IGenericRepositoryAsync<Organizer> _organizerRepository;
        readonly IMapper _mapper;

        public OrganizerService(IGenericRepositoryAsync<Organizer> organizerRepository, IMapper mapper)
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }

        #region crud operations
        public async Task<ICommandResult> CreateOrganizerAsync(OrganizerCreateDto organizerCreateDto)
        {
            var entity = _mapper.Map<Organizer>(organizerCreateDto);
            await _organizerRepository.AddAsync(entity);
            return new SuccessCommandResult("Organiser successfully created.");
        }

        public async Task<ICommandResult> DeleteOrganizerAsync(Guid id)
        {
            var deleteItem = await _organizerRepository.GetAsync(e => e.Id == id);
            if (deleteItem != null)
            {
                await _organizerRepository.DeleteAsync(deleteItem);
                return new SuccessCommandResult("Organiser successfully deleted.");
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<OrganizerDetailDto>> GetOrganizerByIdAsync(Guid id)
        {
            var existItem = await _organizerRepository.GetAsync(e => e.Id == id);
            if (existItem != null)
            {
                var data = _mapper.Map<OrganizerDetailDto>(existItem);
                return new SuccessCommandResult<OrganizerDetailDto>(data);
            }
            return new ErrorCommandResult<OrganizerDetailDto>();
        }

        public async Task<ICommandResult<IEnumerable<OrganizerDetailDto>>> GetOrganizersAsync()
        {
            var itemList = await _organizerRepository.GetAllAsync();

            var data = new List<OrganizerDetailDto>();
            foreach (var item in itemList)
            {
                var entity = _mapper.Map<OrganizerDetailDto>(item);
                data.Add(entity);
            }
            return new SuccessCommandResult<IEnumerable<OrganizerDetailDto>>(data);
        }

        public async Task<ICommandResult> UpdateOrganizerAsync(Organizer organizerItem)
        {
            var existItem = await _organizerRepository.GetAsync(e => e.Id == organizerItem.Id);
            if (existItem != null)
            {
                await _organizerRepository.UpdateAsync(existItem);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
        #endregion
    }
}
