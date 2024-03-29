using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objectOfCategoryList = _unitOfWork.Category.GetAll();
        return View(objectOfCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The display order can not match the name");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(obj);
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

        var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);
        // var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == Id);
        // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == Id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The display order can not match the name");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Update(obj);
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
        var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);
        // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == Id);

        if (categoryFromDbFirst == null)
        {
            return NotFound();
        }

        return View(categoryFromDbFirst);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult DeletePost(int? Id)
    {
        var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Category.Remove(obj);
        _unitOfWork .Save();
        TempData["success"] = "Successful deletion";
        return RedirectToAction("Index");
    }
}