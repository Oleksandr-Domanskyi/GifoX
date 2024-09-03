using System;

namespace Product.Shared.Dtos;

public class CouponeDtoResponse
{
    public Guid CouponId { get; set; }
    public string? CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public string? DiscountType { get; set; }
    public int MinAmount { get; set; }
    public int UsableAmount { get; set; }
    public bool CanBeUsed { get; set; }
}
