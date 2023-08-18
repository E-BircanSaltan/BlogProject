using AutoMapper;
using BlogProject.Business.Abstract;
using BlogProject.Entity.DTO.Article;
using BlogProject.Entity.DTO.Category;
using BlogProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogProject.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ArticleController : Controller
    {
        private readonly IArticleServise _articleServise;
        private readonly IMapper _mapper;
        public ArticleController(IArticleServise articleServise, IMapper mapper)
        {
            _articleServise = articleServise;
            _mapper = mapper;
        }


        [HttpGet("/Articles")]
        [ProducesResponseType(typeof(Sonuc<List<ArticleResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetArticles()
        {
            var _articles = await _articleServise.GetAllAsync();

            if (_articles != null)
            {
                List<ArticleResponseDTO> articleResponseDTOList = new();
                foreach (var article in _articles)
                {
                    articleResponseDTOList.Add(_mapper.Map<ArticleResponseDTO>(article));

                }
                return Ok(Sonuc<List<ArticleResponseDTO>>.SuccussWithData(articleResponseDTOList));
            }
            else
            {

                return NotFound(Sonuc<List<ArticleResponseDTO>>.SuccussNoDataFound());

            }
        }
    }
}
