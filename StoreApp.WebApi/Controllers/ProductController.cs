using Microsoft.AspNetCore.Mvc;

namespace StoreApp.WebApi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
