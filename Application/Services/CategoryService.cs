using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<ICommandResult> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
        Task<ICommandResult> DeleteCategoryAsync(Guid id);
        Task<ICommandResult> UpdateCategoryAsync(Category categoryItem);
        Task<ICommandResult<CategoryDetailDto>> GetCategoryByIdAsync(Guid id);
        Task<ICommandResult<IEnumerable<CategoryDetailDto>>> GetCategoriesAsync();
    }
    public class CategoryService : ICategoryService
    {
        readonly IGenericRepositoryAsync<Category> _categoryRepository;
        readonly IMapper _mapper;

        public CategoryService(IGenericRepositoryAsync<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        #region crud operations
        public async Task<ICommandResult> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            var entity = _mapper.Map<Category>(categoryCreateDto);
            await _categoryRepository.AddAsync(entity);
            return new SuccessCommandResult("Category successfully created.");
        }

        public async Task<ICommandResult> DeleteCategoryAsync(Guid id)
        {
            var deleteItem = await _categoryRepository.GetAsync(e => e.Id == id);
            if (deleteItem != null)
            {
                await _categoryRepository.DeleteAsync(deleteItem);
                return new SuccessCommandResult("Category successfully deleted.");
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<IEnumerable<CategoryDetailDto>>> GetCategoriesAsync()
        {
            var itemList = await _categoryRepository.GetAllAsync();

            var data = new List<CategoryDetailDto>();
            foreach (var item in itemList)
            {
                var entity = _mapper.Map<CategoryDetailDto>(item);
                data.Add(entity);
            }
            return new SuccessCommandResult<IEnumerable<CategoryDetailDto>>(data);
        }

        public async Task<ICommandResult<CategoryDetailDto>> GetCategoryByIdAsync(Guid id)
        {
            var existItem = await _categoryRepository.GetAsync(e => e.Id == id);
            if (existItem != null)
            {
                var data = _mapper.Map<CategoryDetailDto>(existItem);
                return new SuccessCommandResult<CategoryDetailDto>(data);
            }
            return new ErrorCommandResult<CategoryDetailDto>();
        }

        public async Task<ICommandResult> UpdateCategoryAsync(Category categoryItem)
        {
            var existItem = await _categoryRepository.GetAsync(e => e.Id == categoryItem.Id);
            if (existItem != null)
            {
                await _categoryRepository.UpdateAsync(existItem);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
        #endregion
    }
}
