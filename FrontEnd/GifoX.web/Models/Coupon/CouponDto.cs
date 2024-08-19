using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifoX.web.Models.Coupon
{
    public class CouponDto
    {
        public Guid CouponId { get; set; }
        public string CouponCode { get; set; } = default!;
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}