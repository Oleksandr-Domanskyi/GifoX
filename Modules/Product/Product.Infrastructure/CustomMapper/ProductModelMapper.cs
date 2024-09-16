using System;
using Product.Core.Domain;
using Product.Core.Dto;
using Product.Infrastructure.CustomMapper;
using Product.Product.Core.Domain;
using Product.Service.Core.Domain;
using Product.Service.Core.ProductDto.Request;
using Shared.Core.ProductShared.Dto;

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
            PrBrutto = request.PrNetto * 1.2,
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
            PrBrutto = request.PrNetto * 1.2,
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
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Characteristics = model.Characteristics,
            Images = ImageMapper.ImageToImageDto(model.Images).ToList(),
            Category = model.Category,
            SubCategory = model.SubCategory,
            PrNetto = model.PrNetto,
            PrBrutto = model.PrBrutto,
            ClientFeedbacks = ClientsFeedbackMapper.ClientFeedbackToClientFeedbackDto(model.ClientFeedbacks ?? new List<ClientFeedback>()).ToList(),
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
            Images = ImageMapper.ImageToImageDto(model.Images).ToList(),
            Category = model.Category,
            SubCategory = model.SubCategory,
            PrNetto = model.PrNetto,
            PrBrutto = model.PrBrutto,
            ClientFeedbacks = ClientsFeedbackMapper.ClientFeedbackToClientFeedbackDto(model.ClientFeedbacks ?? new List<ClientFeedback>()).ToList(),
            IsActive = model.IsActive,
            CreatedDate = DateTime.UtcNow,
            EndDate = model.IsActive ? default : DateTime.UtcNow.Date,
            UserId = model.UserId
        };
    }

}
