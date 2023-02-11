using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBook.Models;

public class Product
{
    [Key] public int Id { get; set; }
    [Required] public string Title { get; set; }
    public string Description { get; set; }
    [Required] public string ISBN { get; set; }
    [Required] public string Author { get; set; }
    [Required, Range(1, 10000)] public double ListPrice { get; set; }
    [Required, Range(1, 10000)] public double PricePerBook { get; set; }
    [Required, Range(1, 10000)] public double PricePer50Books { get; set; }
    [Required, Range(1, 10000)] public double PricePer100Books { get; set; }
    [Required] public string ImageURL { get; set; }
    [Required] public int CategoryId { get; set; }
    [ForeignKey("CategoryId")] public Category Category { get; set; }
    public int CoverTypeId { get; set; }
    public CoverType CoverType { get; set; }
}