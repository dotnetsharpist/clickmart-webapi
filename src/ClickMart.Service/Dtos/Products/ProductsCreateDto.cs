using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ClickMart.Service.Dtos.Products;

public class ProductsCreateDto
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile Image { get; set; } = default!;

    public double UnitPrice { get; set; }

    public long CategoryId { get; set; }

    public long CompanyId { get; set; }
}
