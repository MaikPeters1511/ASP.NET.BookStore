using asp.mvc.Data;
using asp.mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.mvc.Controllers
{
    public class CategoryController(ApplicationDbContext context) : Controller
    {
        public IEnumerable<Category> GetCategoriesList() => context.Categories;

        public IActionResult Index() => View(GetCategoriesList());

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
