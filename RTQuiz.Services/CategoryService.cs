using AutoMapper;
using RTQuiz.DTO;
using RTQuiz.IRepositories;
using RTQuiz.IServices;
using RTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<GetCategoryDTO> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);
            var savedCategory = await _categoryRepository.CreateAsync(category);
            var savedCategoryDTO = _mapper.Map<GetCategoryDTO>(savedCategory);
            return savedCategoryDTO;
        }

        public async Task<GetCategoryDTO> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoryRepository.GetAsync(id);
            if (categoryToDelete == null)
                return null;
            var categoryDeleted = await _categoryRepository.DeleteAsync(categoryToDelete);
            var categoryDeletedDTO = _mapper.Map<GetCategoryDTO>(categoryDeleted);
            return categoryDeletedDTO;
        }

        public async Task<IEnumerable<GetCategoryDTO>> GetAllCategories()
        {
            var categoryList = await _categoryRepository.GetAllAsync();
            var categoryDTOList = _mapper.Map<IEnumerable<GetCategoryDTO>>(categoryList);
            return categoryDTOList;
        }

        public async Task<GetCategoryDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null) 
                return null;
            var categoryDTO = _mapper.Map<GetCategoryDTO>(category);
            return categoryDTO;
        }

        public async Task<GetCategoryDTO> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var oldCategory = await _categoryRepository.GetAsync(updateCategoryDTO.Id);
            if (oldCategory == null)
                return null;
            var newCategory = _mapper.Map<Category>(updateCategoryDTO);
            var newCategorySaved = await _categoryRepository.UpdateAsync(newCategory);
            var newCategorySavedDTO = _mapper.Map<GetCategoryDTO>(newCategorySaved);
            return newCategorySavedDTO;
        }
    }
}
