using BlogProjectWebUI.Core.DTO.Category;
using BlogProjectWebUI.Core.Result;
using BlogProjectWebUI.Helper;
using BlogProjectWebUI.Helper.SessionHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace BlogProjectWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        [HttpGet("/Admin/Kategori")]
        public async Task <IActionResult> Index()
        {

            var url = "http://localhost:5025/Categories";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            
               RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CategoryDTO>>>(response.Content);
            var categoryList = responseObject.Data;
            return View(categoryList.ToList());
        }
        [ValidateAntiForgeryToken]
        [HttpPost("/AddCategory")]
        public async Task<IActionResult>AddCategory(CategoryDTO category)
        {

            var url = " http://localhost:5025/AddCategory";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(category);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<CategoryDTO>>(response.Content);


            if(response.StatusCode==HttpStatusCode.OK)
            {
                return Json(new { success = true, message = responseObject.Mesaj, data = responseObject.Data });

            }

            else if (response.StatusCode==HttpStatusCode.BadRequest) 
            {
                return Json(new { success = false, message = responseObject.Mesaj, data = responseObject.HataBilgisi });

            }

            else
            {
                return Json(new { success = false, message = "Hata Oluştu,", });
            }
        }


        [ValidateAntiForgeryToken]
        [HttpPost("/Admin/UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryDTO category)
        {
            var url = "http://localhost:5025/UpdateCategory";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);
            var body = JsonConvert.SerializeObject(category);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true, message = responseObject.Mesaj, data = responseObject.Data });
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Json(new { success = false, message = responseObject.Mesaj, data = responseObject.HataBilgisi });
            }

            else
            {
                return Json(new { success = false, message = "Hata Oluştu" });
            }

        }


        [ValidateAntiForgeryToken]
        [HttpPost("/Admin/RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(CategoryDTO categoryDTO)
        {

            var url = "http://localhost:5025/RemoveCategory/";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);
            var body = JsonConvert.SerializeObject(categoryDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true, message = responseObject.Mesaj, data = responseObject.Data });
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Json(new { success = false, message = responseObject.Mesaj, data = responseObject.HataBilgisi });
            }

            else
            {
                return Json(new { success = false, message = "Hata Oluştu" });
            }

        }


        [HttpGet("/AdminKategori/{categoryGUID}")]
        public async Task<ActionResult> GetCategoryDetail(Guid categoryGUID)
        {
            var url = "http://localhost:5025/Category/" + categoryGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<CategoryDTO>>(response.Content);

            return Json(new { success = true, data = responseObject.Data });
        }
    }
}

