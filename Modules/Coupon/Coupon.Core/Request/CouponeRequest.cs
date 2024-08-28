using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Domain.Enums;

namespace Coupons.Service.Core.Request
{
    public class CouponeRequest
    {
        public string CouponCode { get; set; } = default!;
        public double DiscountAmount { get; set; } = default;
        public int MinAmount { get; set; } = default!;
        public string DiscountType { get; set; } = DiscountTypes.FixedAmount.ToString();
        public int UsableAmount { get; set; } = default!;
    }
}