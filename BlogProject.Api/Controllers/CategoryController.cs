using AutoMapper;
using BlogProject.Api.Aspects;
using BlogProject.Api.Validation.FluentValidation;
using BlogProject.Business.Abstract;
using BlogProject.Entity.DTO.Category;
using BlogProject.Entity.DTO.User;
using BlogProject.Entity.Poco;
using BlogProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogProject.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryServise _categoryServise;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryServise categoryServise, IMapper mapper)
        {
            _categoryServise = categoryServise;
            _mapper = mapper;
        }

        [HttpPost("/AddCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> Addcategory(CategoryRequestDTO categoryRequestDTO)
        {
                      
                Category category = _mapper.Map<Category>(categoryRequestDTO);

                await _categoryServise.AddAsync(category);

                CategoryResponseDTO categoryResponseDTO = _mapper.Map<CategoryResponseDTO>(category);

                return Ok(Sonuc<CategoryResponseDTO>.SuccussWithData(categoryResponseDTO));
  
        }

        [HttpGet("/Categories")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategories()
        {
            var _categories = await _categoryServise.GetAllAsync();

            if (_categories != null)
            {
                List<CategoryResponseDTO> categoryResponseDTOList = new();
                foreach (var category in _categories)
                {
                    categoryResponseDTOList.Add(_mapper.Map<CategoryResponseDTO>(category));

                }
                return Ok(Sonuc<List<CategoryResponseDTO>>.SuccussWithData(categoryResponseDTOList));
            }
            else 
            { 
            
            return NotFound(Sonuc<List<CategoryResponseDTO>>.SuccussNoDataFound());
            
            }
        }





        [HttpGet("/Category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryServise.GetAsync(q=>q.id==id);

            if (category != null)
            {
                CategoryResponseDTO categoryResponseDTO = new();
                
                    categoryResponseDTO=_mapper.Map<CategoryResponseDTO>(category);

               
                return Ok(Sonuc<CategoryResponseDTO>.SuccussWithData(categoryResponseDTO));
            }
            else
            {

                return NotFound(Sonuc<List<CategoryResponseDTO>>.SuccussNoDataFound());

            }
        }
    }

}
