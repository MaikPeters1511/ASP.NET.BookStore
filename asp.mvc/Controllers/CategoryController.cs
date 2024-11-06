using asp.DataAccess.Data;
using asp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                    TempData["Success"] = "Category created successfully.";
                    return RedirectToAction(nameof(Index));
                default:
                    return View(category);
            }
        }

        // GET: Category/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            switch (ModelState.IsValid)
            {
                case true:
                    context.Categories.Update(category);
                    context.SaveChangesAsync();
                    TempData["Success"] = "Category updated successfully.";
                    return RedirectToAction(nameof(Index));
                default:
                    return View(category);
            }
        }

        // GET: Category/Delete/1
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            TempData["Success"] = "Category deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
