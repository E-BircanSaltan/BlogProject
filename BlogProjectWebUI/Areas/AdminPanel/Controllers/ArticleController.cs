using BlogProjectWebUI.Core.DTO.Article;
using BlogProjectWebUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace BlogProjectWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ArticleController : Controller
    {
        [HttpGet("/Admin/Makaleler")]
        public async Task<IActionResult> Index()
        {

            var url = "http://localhost:5025/Articles";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<ArticleDTO>>>(response.Content);
            var articleList = responseObject.Data;
            return View(articleList.ToList());
        }
    }
}
