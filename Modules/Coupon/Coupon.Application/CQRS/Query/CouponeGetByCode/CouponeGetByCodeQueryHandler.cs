using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using Coupons.Service.Infrastructure.Repositories;
using Coupons.Service.Infrastructure.Services.RepositoryServices;
using MediatR;

namespace Coupon.Service.Application.CQRS.Query.CouponeGetByCode
{
    public class CouponeGetByCodeQueryHandler : IRequestHandler<CouponeGetByCodeQuery, CouponDto>
    {
        private readonly ICouponeRepositoryService _couponeRepositoryService;
        public CouponeGetByCodeQueryHandler(ICouponeRepositoryService couponeRepositoryService)
        {
            _couponeRepositoryService = couponeRepositoryService;

        }
        public async Task<CouponDto> Handle(CouponeGetByCodeQuery request, CancellationToken cancellationToken)
        {
            var model = await _couponeRepositoryService.GetByCode(request.Code);
            if (!model.IsSuccess)
            {
                throw new Exception($"Coupone get by code Failed, errors: {string.Join(" ", model.Errors.Select(e => e.Message))}");
            }
            return model.Value;

        }
    }
}