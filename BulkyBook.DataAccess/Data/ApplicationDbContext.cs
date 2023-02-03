using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    public DbSet<Category> Categories { get; set; }

}