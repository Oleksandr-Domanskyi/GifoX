using System;
using Microsoft.AspNetCore.Http;
using Product.Core.Domain;
using Product.Core.Dto.Request;
using static Shared.Shared.Core.ProductShared.Enums.Category;

namespace Product.Service.Core.ProductDto.Request;

public class ProductRequest
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<string>? Characteristics { get; set; }
    public List<IFormFile>? Images { get; set; }
    public MainCategory Category { get; set; } = MainCategory.Others;
    public SubMainCategory SubCategory { get; set; } = SubMainCategory.Others;
    public double PrNetto { get; set; }
    public bool IsActive { get; set; } = true;
    
}
