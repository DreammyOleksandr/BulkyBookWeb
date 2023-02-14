using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> objectOfProductList = _unitOfWork.Product.GetAll();
        return View(objectOfProductList);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Upsert(Product obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Product.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Successful creation";
            return RedirectToAction("Index");
        }
        else
            return View(obj);
    }

    public IActionResult Upsert(int? Id)
    {
        ProductVM productVm = new()
        {
            Product = new(),
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem(
            {
            }));
        }
        if (Id == null || Id == 0)
        {
            ViewBag.CategoryList = categoryList;
            ViewData["CoverTypeList"] = coverTypeList;
            return View(product);
        }
        else
        {
        }

        return View(product);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult DeletePost(int? Id)
    {
        var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == Id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Product.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Successful deletion";
        return RedirectToAction("Index");
    }
}