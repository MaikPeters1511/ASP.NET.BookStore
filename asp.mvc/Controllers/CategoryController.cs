using Microsoft.AspNetCore.Mvc;

namespace asp.mvc.Controllers
{
    public class CategoryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
