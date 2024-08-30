using System;
using Product.Core.Domain;
using Product.Service.Core.Domain;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Core.Dto;

public class ProductDto
{
    public Guid Id { get; set;}
    public string? Name { get; set;}
    public string? Description { get; set;}
    public List<string>? Characteristics { get; set;}
    public List<Image>? Images{ get; set;}
    public MainCategory Category { get; set;}
    public SubMainCategory SubMainCategory { get; set;}
    public double PrNetto { get; set;}
    public double PrBrutto { get; set;}
    public List<ClientFeedback>? ClientFeedbacks { get; set;}
    private bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? UserId { get; set; }

}
