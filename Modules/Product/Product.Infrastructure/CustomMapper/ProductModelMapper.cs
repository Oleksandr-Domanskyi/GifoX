using System;
using Product.Core.Dto;
using Product.Service.Core.Domain;
using Product.Service.Core.ProductDto.Request;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Product.Infrastructure.CustomMapper;

public class ProductModelMapper
{

    public static ProductModel MapProductRequestToProductModel(ProductRequest request, string userId)
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
    public static ProductModel MapProductRequestToProductModel(ProductRequest request, Guid ProduictId, string userId)
    {
        return new ProductModel
        {
            Id = ProduictId,
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
    public static IEnumerable<ProductDto> MapProductModelToProductDto(IEnumerable<ProductModel> models)
    {
        return models.Select(model => new ProductDto
        {
            Name = model.Name,
            Description = model.Description,
            Characteristics = model.Characteristics,
            Images = model.Images,
            Category = model.Category,
            SubCategory = model.SubCategory,
            PrNetto = model.PrNetto,
            PrBrutto = default,
            ClientFeedbacks = model.ClientFeedbacks,
            IsActive = model.IsActive,
            CreatedDate = DateTime.UtcNow,
            EndDate = model.IsActive ? default : DateTime.UtcNow.Date,
            UserId = model.UserId
        });
    }
    public static ProductDto MapProductModelToProductDto(ProductModel model)
    {
        return new ProductDto
        {
            Name = model.Name,
            Description = model.Description,
            Characteristics = model.Characteristics,
            Images = model.Images,
            Category = model.Category,
            SubCategory = model.SubCategory,
            PrNetto = model.PrNetto,
            PrBrutto = default,
            ClientFeedbacks = model.ClientFeedbacks,
            IsActive = model.IsActive,
            CreatedDate = DateTime.UtcNow,
            EndDate = model.IsActive ? default : DateTime.UtcNow.Date,
            UserId = model.UserId
        };
    }

}
