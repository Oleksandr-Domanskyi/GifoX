using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Infrastructure.Services.RepositoryServices;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeCreate
{
    public class CouponeCreateCommandHandler : IRequestHandler<CouponeCreateCommand>
    {
        private readonly ICouponeRepositoryService _couponeRepositoryService;

        public CouponeCreateCommandHandler(ICouponeRepositoryService couponeRepositoryService)
        {
            _couponeRepositoryService = couponeRepositoryService;
        }
        public async Task Handle(CouponeCreateCommand request, CancellationToken cancellationToken)
        {
            var model = await _couponeRepositoryService.AddCoupone(request.CouponeRequest);
            if (!model.IsSuccess)
            {
                throw new Exception($"Coupone Create was Failed, errors: {model.Errors.Select(x => x.Message)}");
            }
            return;
        }
    }
}