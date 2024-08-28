using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using MediatR;

namespace Coupon.Service.Application.CQRS.Query.CouponeGetById
{
    public class CouponeGetByIdQuery : IRequest<CouponDto>
    {
        public Guid Id { get; set; }
        public CouponeGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}