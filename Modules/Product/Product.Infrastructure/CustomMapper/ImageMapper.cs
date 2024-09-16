using System;
using Product.Service.Core.Domain;
using Shared.Core.ProductShared.Dto;

namespace Product.Infrastructure.CustomMapper;

public class ImageMapper
{
    public static ImageDto ImageToImageDto(Image? image)
    {
        return image == null ? new ImageDto() : new ImageDto
        {
            Id = image.Id,
            Url = image.Url,
            ProductId = image.ProductId,
        };
    }
    public static IEnumerable<ImageDto> ImageToImageDto(IEnumerable<Image>? images)
    {
        return images == null ? new List<ImageDto>() : images.Select(image => new ImageDto
        {
            Id = image.Id,
            Url = image.Url,
            ProductId = image.ProductId,
        });
    }

}
