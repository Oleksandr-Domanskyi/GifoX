using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Request;
using Coupons.Service.Core.Domain;

namespace Coupons.Service.Core.Dto
{
    public class CouponDto
    {
        public Guid CouponId { get; set; }
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public string? DiscountType { get; set; }
        public int MinAmount { get; set; }
        public int UsableAmount { get; set; }
        public bool CanBeUsed { get; set; }
    }
}