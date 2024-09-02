using RTQuiz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IServices
{
    public interface ICategoryService 
    {
        Task<IEnumerable<GetCategoryDTO>> GetAllCategories();
        Task<GetCategoryDTO> GetCategoryById(int id);
        Task<GetCategoryDTO> CreateCategory(CreateCategoryDTO createCategoryDTO);
        Task<GetCategoryDTO> UpdateCategory(UpdateCategoryDTO updateCategoryDTO);
        Task<GetCategoryDTO> DeleteCategory(int id);
    }
}
