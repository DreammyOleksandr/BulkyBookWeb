using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objectOfCategoryList = _db.Categories;
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
            _db.Categories.Add(obj);
            _db.SaveChanges();
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

        var categoryFromDb = _db.Categories.Find(Id);
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
            _db.Categories.Update(obj);
            _db.SaveChanges();
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

        var categoryFromDb = _db.Categories.Find(Id);
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
    public IActionResult DeletePost(int? Id)
    {
        var obj = _db.Categories.Find(Id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Successful deletion";
        return RedirectToAction("Index");
    }
}