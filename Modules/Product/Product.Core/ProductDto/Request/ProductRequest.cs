using System;
using Microsoft.AspNetCore.Http;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Service.Core.ProductDto.Request;

public class ProductRequest
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<IFormFile>? Images { get; set; }
    public MainCategory Category { get; set; } = MainCategory.Others;
    public bool IsActive { get; set; } = true;
    public Enum? SubCategory { get; set; } = null;
    public double PrNetto { get; set; }
}
