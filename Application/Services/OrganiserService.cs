using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;

namespace Application.Services
{
    public interface IOrganiserService
    {
        Task<ICommandResult> CreateOrganiserAsync(OrganiserCreateDto organiserCreateDto);
        Task<ICommandResult> DeleteOrganiserAsync(Guid id);
        Task<ICommandResult> UpdateOrganiserAsync(Organiser organiserItem);
        Task<ICommandResult<OrganiserDetailDto>> GetOrganiserByIdAsync(Guid id);
        Task<ICommandResult<IEnumerable<OrganiserDetailDto>>> GetOrganisersAsync();
    }
    public class OrganiserService : IOrganiserService
    {
        readonly IGenericRepositoryAsync<Organiser> _organiserRepository;
        readonly IMapper _mapper;

        public OrganiserService(IGenericRepositoryAsync<Organiser> organiserRepository, IMapper mapper)
        {
            _organiserRepository = organiserRepository;
            _mapper = mapper;
        }

        #region crud operations
        public async Task<ICommandResult> CreateOrganiserAsync(OrganiserCreateDto organiserCreateDto)
        {
            var entity = _mapper.Map<Organiser>(organiserCreateDto);
            await _organiserRepository.AddAsync(entity);
            return new SuccessCommandResult("Organiser successfully created.");
        }

        public async Task<ICommandResult> DeleteOrganiserAsync(Guid id)
        {
            var deleteItem = await _organiserRepository.GetAsync(e => e.Id == id);
            if (deleteItem != null)
            {
                await _organiserRepository.DeleteAsync(deleteItem);
                return new SuccessCommandResult("Organiser successfully deleted.");
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<OrganiserDetailDto>> GetOrganiserByIdAsync(Guid id)
        {
            var existItem = await _organiserRepository.GetAsync(e => e.Id == id);
            if (existItem != null)
            {
                var data = _mapper.Map<OrganiserDetailDto>(existItem);
                return new SuccessCommandResult<OrganiserDetailDto>(data);
            }
            return new ErrorCommandResult<OrganiserDetailDto>();
        }

        public async Task<ICommandResult<IEnumerable<OrganiserDetailDto>>> GetOrganisersAsync()
        {
            var itemList = await _organiserRepository.GetAllAsync();

            var data = new List<OrganiserDetailDto>();
            foreach (var item in itemList)
            {
                var entity = _mapper.Map<OrganiserDetailDto>(item);
                data.Add(entity);
            }
            return new SuccessCommandResult<IEnumerable<OrganiserDetailDto>>(data);
        }

        public async Task<ICommandResult> UpdateOrganiserAsync(Organiser organiserItem)
        {
            var existItem = await _organiserRepository.GetAsync(e => e.Id == organiserItem.Id);
            if (existItem != null)
            {
                await _organiserRepository.UpdateAsync(existItem);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
        #endregion
    }
}
