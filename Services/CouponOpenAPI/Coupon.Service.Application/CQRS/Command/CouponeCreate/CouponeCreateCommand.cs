using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Request;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeCreate
{
    public class CouponeCreateCommand : IRequest
    {
        public CouponeRequest CouponeRequest { get; set; }
        public CouponeCreateCommand(CouponeRequest couponeRequest)
        {
            CouponeRequest = couponeRequest;
        }

    }
}