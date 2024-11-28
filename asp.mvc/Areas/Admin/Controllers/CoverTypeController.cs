using System.Globalization;
using asp.DataAccess.Repository.IRepository;
using asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class CoverTypeController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public IEnumerable<CoverType> GetCoverTypesList() => _unitOfWork.CoverType.GetAll();

    public IActionResult Index() => View(GetCoverTypesList());

    // GET: CoverType/Create
    public IActionResult Create() => View();

    // POST: CoverType/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType coverType)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(coverType);
            _unitOfWork.Save();
            TempData["Success"] = "CoverType created successfully.";
            return RedirectToAction(nameof(Index));
        }
        return View(coverType);
    }

    // GET: CoverType/Edit/1
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }
        var coverType = await _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);

        if (coverType == null)
        {
            return NotFound();
        }
        return View(coverType);
    }

    // POST: CoverType/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType coverType)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(coverType);
            _unitOfWork.Save();
            TempData["Success"] = "CoverType updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        return View(coverType);
    }

    // GET: CoverType/Delete/1
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }
        var coverType = await _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);

        if (coverType == null)
        {
            return NotFound();
        }
        return View(coverType);
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
        var coverType = await _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);

        if (coverType == null)
        {
            return NotFound();
        }
        _unitOfWork.CoverType.Remove(coverType);
        _unitOfWork.Save();
        TempData["Success"] = "CoverType deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route("Admin/CoverType/GetCoverType")]
    public IActionResult GetCoverType()
    {
        var getCoverType = _unitOfWork.CoverType.GetAll()
            .Select(c => new { c.Id, c.Name });

        return new JsonResult(getCoverType);
    }
}
