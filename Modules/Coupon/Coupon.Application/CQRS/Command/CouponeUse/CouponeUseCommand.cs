using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeUse
{
    public class CouponeUseCommand : IRequest<CouponDto>
    {
        public string Code { get; set; }
        public CouponeUseCommand(string code)
        {
            Code = code;
        }
    }
}