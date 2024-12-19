using System.Globalization;
using asp.DataAccess.Repository.IRepository;
using asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public IEnumerable<Product> GetProductsList() => _unitOfWork.Product.GetAll();

    public IActionResult Index() => View(GetProductsList());

    // GET: CoverType/Create
    public IActionResult Create() => View();

    // POST: CoverType/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product created successfully.";
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: CoverType/Edit/1
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }
        var product = await _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: CoverType/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: CoverType/Delete/1
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }
        var product = await _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: CoverType/Delete/1
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }
        var product = await _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        _unitOfWork.Product.Remove(product);
        _unitOfWork.Save();
        TempData["Success"] = "Product deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route("Admin/CoverType/GetCoverType")]
    public IActionResult GetProduct()
    {
        var getProduct = _unitOfWork.Product.GetAll()
            .Select(c => new { c.Id });

        return new JsonResult(getProduct);
    }
}
