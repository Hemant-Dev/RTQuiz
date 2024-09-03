using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RTQuiz.DTO;
using RTQuiz.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RTQuiz.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<GetCategoryDTO>> GetAll()
        {
            var res = await _categoryService.GetAllCategories();
            return res;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<GetCategoryDTO> Get(int id)
        {
            var res = await _categoryService.GetCategoryById(id);
            return res;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<GetCategoryDTO> Post([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            var res = await _categoryService.CreateCategory(createCategoryDTO);
            return res;
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<GetCategoryDTO> Put(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            if (id != updateCategoryDTO.Id)
                return null;
            var res = await _categoryService.UpdateCategory(updateCategoryDTO);
            return res;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<GetCategoryDTO> Delete(int id)
        {
            var res = await _categoryService.DeleteCategory(id);
            return res;
        }
    }
}
