using System;

namespace Shared.Core.ProductShared.Dto;

public class ImageDto
{
    public Guid Id { get; set; }
    public string? Url {get; set; }
    public Guid ProductId { get; set; }
}
