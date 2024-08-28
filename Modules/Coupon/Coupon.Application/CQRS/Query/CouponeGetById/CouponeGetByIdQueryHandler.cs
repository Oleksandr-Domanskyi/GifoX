using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using Coupons.Service.Infrastructure.Services.RepositoryServices;
using MediatR;

namespace Coupon.Service.Application.CQRS.Query.CouponeGetById
{
    public class CouponeGetByIdQueryHandler : IRequestHandler<CouponeGetByIdQuery, CouponDto>
    {
        private readonly ICouponeRepositoryService _couponeRepositoryService;
        public CouponeGetByIdQueryHandler(ICouponeRepositoryService couponeRepositoryService)
        {
            _couponeRepositoryService = couponeRepositoryService;
        }
        public async Task<CouponDto> Handle(CouponeGetByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _couponeRepositoryService.GetById(request.Id);
            if (!model.IsSuccess)
            {
                throw new Exception($"Coupone get by id was Failed, errors: {string.Join(" ", model.Errors.Select(e => e.Message))}");
            }
            return model.Value;
        }
    }
}