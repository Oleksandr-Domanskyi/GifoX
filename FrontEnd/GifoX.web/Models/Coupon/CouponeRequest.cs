using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifoX.web.Models.Coupon
{
    public class CouponeRequest
    {
        public string CouponCode { get; set; } = default!;
        public double DiscountAmount { get; set; } = default;
        public int MinAmount { get; set; } = default!;
        public string DiscountType { get; set; } = default!;
        public int UsableAmount { get; set; } = default!;
    }
}