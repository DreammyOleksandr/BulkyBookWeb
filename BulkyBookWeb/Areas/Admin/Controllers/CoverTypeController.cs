using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBookWeb.Controllers;

[Area("Admin")]
public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<CoverType> objectOfCoverTypeList = _unitOfWork.CoverType.GetAll();
        return View(objectOfCoverTypeList);
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Successful creation";
            return RedirectToAction("Index");
        }
        else
            return View(obj);
    }

    public IActionResult Edit(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }

        var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == Id);
        // var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == Id);
        // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == Id);

        if (coverTypeFromDb == null)
        {
            return NotFound();
        }

        return View(coverTypeFromDb);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Successful update";
            return RedirectToAction("Index");
        }

        else
            return View(obj);
    }

    public IActionResult Delete(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }

        // var categoryFromDb = _db.Categories.Find(Id);
        var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == Id);
        // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == Id);

        if (coverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(coverTypeFromDbFirst);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult DeletePost(int? Id)
    {
        var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == Id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Successful deletion";
        return RedirectToAction("Index");
    }
}