using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using MediatR;

namespace Coupons.Service.Application.CQRS.Query.CouponeGetAll
{
    public class CouponeGetAllQuery : IRequest<IEnumerable<CouponDto>>
    {

    }
}