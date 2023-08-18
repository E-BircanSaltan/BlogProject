using BlogProjectWebUI.Core.Model;
using BlogProjectWebUI.Helper;
using BlogProjectWebUI.Helper.SessionHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BlogProjectWebUI.Areas.AdminPanel.Controllers
{
    [Area("/AdminPanel")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public HomeController(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }


        [HttpGet("/Admin/Anasayfa")]
        public IActionResult Index()
        {

            UserViewModel userViewModel = new()
            {
                AdSoyad = SessionManager.LoggedUser.AdSoyad,
                
            };

            return View(userViewModel);



           
        }
    }
}

