using AutoMapper;
using BlogProject.Business.Abstract;
using BlogProject.Entity.DTO.Article;
using BlogProject.Entity.DTO.Category;
using BlogProject.Entity.Poco;
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
        private readonly ICategoryServise _categoryServise;
        private readonly IMapper _mapper;
        public ArticleController(IArticleServise articleServise, IMapper mapper, ICategoryServise categoryServise)
        {
            _articleServise = articleServise;
            _mapper = mapper;
            _categoryServise = categoryServise;
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
        [HttpGet("/Article/{articleGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<ArticleResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetProduct(Guid articleGUID)
        {
            var article = await _articleServise.GetAsync(q => q.Guid == articleGUID, "Category");
          
            if (article != null)
            {
                ArticleResponseDTO articleResponseDTO = _mapper.Map<ArticleResponseDTO>(article);

                return Ok(Sonuc<ArticleResponseDTO>.SuccussWithData(articleResponseDTO));
            }
            else
            {
                return NotFound(Sonuc<ArticleResponseDTO>.SuccussNoDataFound());
            }
        }
        [HttpPost("/AddArticles")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult>AddArticle(ArticleRequestDTO articleDTO)
        {
            Category category = await _categoryServise.GetAsync(q => q.Guid == articleDTO.CategoryGuid);
             Article article =_mapper.Map<Article>(articleDTO);
            article.Category = category;
                await _articleServise.AddAsync(article);
             return Ok(Sonuc<bool>.SuccussWithData(true));
        }

        [HttpPost("/UpdateArticle")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateArticle([FromBody] ArticleRequestDTO articleDTO)
        {
            Article article = await _articleServise
                .GetAsync(q => q.Guid == articleDTO.Guid);

            Category category = await _categoryServise.GetAsync(q => q.Guid == articleDTO.CategoryGuid);

            article.Category = category;
            article.Title = articleDTO.Title;
            
            await _articleServise.UpdateAsync(article);

            return Ok(Sonuc<bool>.SuccussWithData(true));
        }
    }
}
