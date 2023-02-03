using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
    }

    public ICategoryRepository Category { get; private set; }

    public void Save()
    {
        _db.SaveChanges();
    }
}