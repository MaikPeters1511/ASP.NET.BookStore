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
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            switch (ModelState.IsValid)
            {
                case true:
                    context.Categories.Add(category);
                    context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                default:
                    return View(category);
            }
        }
    }
}
