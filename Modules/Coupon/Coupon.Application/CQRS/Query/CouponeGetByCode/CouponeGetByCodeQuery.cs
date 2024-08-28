using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Domain;
using Coupons.Service.Core.Dto;
using MediatR;

namespace Coupon.Service.Application.CQRS.Query.CouponeGetByCode
{
    public class CouponeGetByCodeQuery : IRequest<Coupons.Service.Core.Dto.CouponDto>
    {
        public string Code { get; set; }
        public CouponeGetByCodeQuery(string code)
        {
            Code = code;
        }

    }
}