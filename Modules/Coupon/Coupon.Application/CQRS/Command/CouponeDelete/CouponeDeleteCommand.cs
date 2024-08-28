using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeDelete
{
    public class CouponeDeleteCommand : IRequest
    {
        public Guid Id { get; set; }
        public CouponeDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}