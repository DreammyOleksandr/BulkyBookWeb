using System.Linq.Expressions;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;
    
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category obj)
    {
        _db.Update(obj);
    }
}