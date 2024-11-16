using System.Globalization;
using asp.DataAccess.Repository.IRepository;
using asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.mvc.Controllers;

internal class CategoryController(IUnitOfWork unitOfWork) : Controller
{
	private readonly IUnitOfWork _unitOfWork = unitOfWork;

	public IEnumerable<Category> GetCategoriesList() => _unitOfWork.Category.GetAll();

	public IActionResult Index() => View(GetCategoriesList());

	// GET: Category/Create
	public IActionResult Create() => View();

	// POST: Category/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(Category category)
	{
		if (category.Name == category.DisplayOrder.ToString(CultureInfo.InvariantCulture))
		{
			ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
		}
		if (ModelState.IsValid)
		{
			_unitOfWork.Category.Add(category);
			_unitOfWork.Save();
			TempData["Success"] = "Category created successfully.";
			return RedirectToAction(nameof(Index));
		}
		return View(category);
	}

	// GET: Category/Edit/1
	public async Task<IActionResult> Edit(int? id)
	{
		if (id is null or 0)
		{
			return NotFound();
		}
		var category = await _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);

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
		if (category.Name == category.DisplayOrder.ToString(CultureInfo.InvariantCulture))
		{
			ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
		}
		if (ModelState.IsValid)
		{
			_unitOfWork.Category.Update(category);
			_unitOfWork.Save();
			TempData["Success"] = "Category updated successfully.";
			return RedirectToAction(nameof(Index));
		}
		return View(category);
	}

	// GET: Category/Delete/1
	public async Task<IActionResult> Delete(int? id)
	{
		if (id is null or 0)
		{
			return NotFound();
		}
		var category = await _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);

		if (category == null)
		{
			return NotFound();
		}
		return View("Delete", category);
	}

	// POST: Category/Delete/1
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int? id)
	{
		if (id is null or 0)
		{
			return NotFound();
		}
		var category = await _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);

		if (category == null)
		{
			return NotFound();
		}
		_unitOfWork.Category.Remove(category);
		_unitOfWork.Save();
		TempData["Success"] = "Category deleted successfully.";
		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public IActionResult GetCategories()
	{
		var categories = _unitOfWork.Category.GetAll()
			.Select(c => new { c.Id, c.Name, c.DisplayOrder });

		return new JsonResult(categories);
	}
}
