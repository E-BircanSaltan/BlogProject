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


        [HttpPost("/UpdateCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> UpdateCategory(CategoryRequestDTO categoryRequestDTO)
        {

            Category category = await _categoryServise.GetAsync(q => q.Guid == categoryRequestDTO.Guid);
            category.Name = categoryRequestDTO.Name;
            await _categoryServise.UpdateAsync(category);

            return Ok(Sonuc<bool>.SuccussWithData(true));

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





        [HttpGet("/ActiveCategories")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetCategories_Active()
        {
            var categories = await _categoryServise.GetAllAsync(q => q.IsActive == true && q.IsDelete == false);
            //categories = null;
            if (categories != null)
            {
                List<CategoryResponseDTO> categoryDTOResponseList = new();

                foreach (var category in categories)
                {
                    categoryDTOResponseList.Add(_mapper.Map<CategoryResponseDTO>(category));
                }
                return Ok(Sonuc<List<CategoryResponseDTO>>.SuccussWithData(categoryDTOResponseList));
            }
            else
            {
                return NotFound(Sonuc<List<CategoryResponseDTO>>.SuccussNoDataFound());
            }
        }


        [HttpGet("/Category/{categoryGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetCategory(Guid categoryGUID)
        {
            var category = await _categoryServise.GetAsync(q => q.Guid == categoryGUID);
            //categories = null;
            if (category != null)
            {
                CategoryResponseDTO categoryDTOResponse = new();


                categoryDTOResponse = _mapper.Map<CategoryResponseDTO>(category);

                return Ok(Sonuc<CategoryResponseDTO>.SuccussWithData(categoryDTOResponse));
            }
            else
            {
                return NotFound(Sonuc<List<CategoryResponseDTO>>.SuccussNoDataFound());
            }



        }

        [HttpPost("/RemoveCategory")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveCategory(CategoryRequestDTO categoryDTORequest)
        {
            Category category = await _categoryServise.GetAsync(q => q.Guid == categoryDTORequest.Guid);
            category.IsActive = false;
            category.IsDelete = true;
            await _categoryServise.UpdateAsync(category);
            return Ok(Sonuc<bool>.SuccussWithData(true));
        }

    }
}
   
