using Shared.Shared.Core.Enum.CouponEnum;

namespace Coupons.Service.Core.Request
{
    public class CouponeRequest
    {
        public string CouponCode { get; set; } = default!;
        public double DiscountAmount { get; set; } = default;
        public int MinAmount { get; set; } = default!;
        public string DiscountType { get; set; } = CouponDiscountTypes.FixedAmount.ToString();
        public int UsableAmount { get; set; } = default!;
    }
}