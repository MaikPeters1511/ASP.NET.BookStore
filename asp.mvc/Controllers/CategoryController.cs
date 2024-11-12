using System.Diagnostics.CodeAnalysis;
using asp.DataAccess.Data;
using asp.DataAccess.Repository.IRepository;
using asp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.mvc.Controllers;

public class CategoryController(IGategoryRepository context) : Controller
{
    private readonly IGategoryRepository _context = context;

    public IEnumerable<Category> GetCategoriesList() => _context.GetAll();

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
        if (ModelState.IsValid)
        {
            _context.Add(category);
            _context.Update(category);
            TempData["Success"] = "Category created successfully.";
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: Category/Edit/1
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var category = await _context.GetFirstOrDefault(x=>x.Name == "id");

        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    // POST: Category/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _context.Update(category);
            _context.Save();
            TempData["Success"] = "Category updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: Category/Delete/1
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var category = await _context.GetFirstOrDefault(x=>x.Name == "id");

        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    // POST: Category/Delete/1
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var category = await _context.GetFirstOrDefault(x=>x.Name == "id");

        if (category == null)
        {
            return NotFound();
        }
        _context.Remove(category);
        _context.Save();
        TempData["Success"] = "Category deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _context.GetAll()
            .Select(c => new { c.Id, c.Name, c.DisplayOrder });

        return new JsonResult(categories);
    }
}
