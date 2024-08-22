using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Request;
using Coupons.Service.Core.Domain;
using Coupons.Service.Core.Dto;

namespace Coupons.Service.Application.Mappers
{
    public class CouponeMapper
    {
        public static Core.Domain.CouponModel MapCouponeRequestToCouponModel(CouponeRequest request, Guid? Id = null)
        {
            return new Core.Domain.CouponModel
            {
                Id = Id ?? Guid.Empty,
                CouponCode = request.CouponCode,
                DiscountAmount = request.DiscountAmount,
                MinAmount = request.MinAmount,
                DiscountType = request.DiscountType,
                UsableAmount = request.UsableAmount
            };
        }
        public static Core.Dto.CouponDto MapCouponModelToCouponDto(Core.Domain.CouponModel domain)
        {
            return new Core.Dto.CouponDto
            {
                CouponId = domain.Id,
                CouponCode = domain.CouponCode,
                DiscountAmount = domain.DiscountAmount,
                DiscountType = domain.DiscountType,
                MinAmount = domain.MinAmount,
                UsableAmount = domain.UsableAmount,
                CanBeUsed = domain.CanBeUsed,
            };
        }
        public static List<Core.Dto.CouponDto> MapCouponModelToCouponDto(IEnumerable<Core.Domain.CouponModel> domains)
        {
            return domains.Select(domain => new CouponDto
            {
                CouponId = domain.Id,
                CouponCode = domain.CouponCode,
                DiscountAmount = domain.DiscountAmount,
                DiscountType = domain.DiscountType,
                MinAmount = domain.MinAmount,
                UsableAmount = domain.UsableAmount,
                CanBeUsed = domain.CanBeUsed,
            }).ToList();
        }
    }
}