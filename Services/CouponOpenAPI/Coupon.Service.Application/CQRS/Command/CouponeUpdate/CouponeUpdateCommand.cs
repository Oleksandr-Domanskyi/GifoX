using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using Coupons.Service.Core.Request;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeUpdate
{
    public class CouponeUpdateCommand : IRequest<CouponDto>
    {
        public Guid Id { get; set; }
        public CouponeRequest CouponeRequest { get; set; }
        public CouponeUpdateCommand(CouponeRequest couponeRequest, Guid id)
        {
            CouponeRequest = couponeRequest;
            Id = id;
        }
    }
}