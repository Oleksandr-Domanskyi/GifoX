using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using Coupons.Service.Infrastructure.Services.RepositoryServices;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeUse
{
    public class CouponeUseCommandHandler : IRequestHandler<CouponeUseCommand, CouponDto>
    {
        private readonly ICouponeRepositoryService _couponeRepositoryService;
        public CouponeUseCommandHandler(ICouponeRepositoryService couponeRepositoryService)
        {
            _couponeRepositoryService = couponeRepositoryService;
        }
        public async Task<CouponDto> Handle(CouponeUseCommand request, CancellationToken cancellationToken)
        {
            var model = await _couponeRepositoryService.UseCoupone(request.Code);
            if (!model.IsSuccess)
            {
                throw new Exception($"Coupone Use was Failed, errors: {string.Join(", ", model.Errors.Select(e => e.Message))}");
            }
            return model.Value;
        }
    }
}