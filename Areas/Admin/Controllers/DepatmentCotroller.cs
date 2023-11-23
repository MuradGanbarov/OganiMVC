using Microsoft.AspNetCore.Mvc;

namespace OganiMVC.Areas.Admin.Controllers
{
    public class DepatmentCotroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
