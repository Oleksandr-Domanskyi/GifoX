using System;
using Product.Service.Core.Domain;
using Product.Service.Core.ProductDto.Request;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Service.Infrastructure.CustomMapper;

public class ProductModelMapper
{
    public ProductModel MapProductRequestToProductModel(ProductRequest request, string userId)
    {
        return new ProductModel
        {
            Name = request.Name,
            Description = request.Description,
            Images = request.Images != null ? new List<Image>() : new List<Image>(),
            Category = request.Category,
            SubCategory = request.SubCategory,
            PrNetto = request.PrNetto,
            PrBrutto = default,
            IsActive = request.IsActive,
            CreatedDate = DateTime.UtcNow,
            EndDate = request.IsActive ? default : DateTime.UtcNow.Date,
            UserId = userId
        };
    }

}
