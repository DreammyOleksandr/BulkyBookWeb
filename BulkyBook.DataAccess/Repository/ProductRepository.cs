using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Product obj)
    {
        var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
        if (objFromDb != null)
        {
            objFromDb.Title = obj.Title;
            objFromDb.CoverType = obj.CoverType;
            objFromDb.CoverTypeId = obj.CoverTypeId;
            objFromDb.Category = obj.Category;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.Author = obj.Author;
            objFromDb.Description = obj.Description;
            objFromDb.ListPrice = obj.ListPrice;
            objFromDb.PricePerBook = obj.PricePerBook;
            objFromDb.PricePer50Books = obj.PricePer50Books;
            objFromDb.PricePer100Books = obj.PricePer100Books;
            objFromDb.ISBN = obj.ISBN;
            if (obj.ImageURL != null)
            {
                objFromDb.ImageURL = obj.ImageURL;
            }
        }
    }
}