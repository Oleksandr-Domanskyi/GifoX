using System;
using static Shared.Shared.Core.ProductShared.Enums.Category;

namespace Shared.Core.ProductShared.Dto;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string>? Characteristics { get; set; }
    public List<ImageDto>? Images { get; set; }
    public MainCategory Category { get; set; }
    public SubMainCategory SubCategory { get; set; }
    public double PrNetto { get; set; }
    public double PrBrutto { get; set; }
    public List<ClientFeedbackDto>? ClientFeedbacks { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? UserId { get; set; }

}