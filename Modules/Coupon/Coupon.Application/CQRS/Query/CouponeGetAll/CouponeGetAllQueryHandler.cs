using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using Coupons.Service.Infrastructure.Services.RepositoryServices;
using MediatR;

namespace Coupons.Service.Application.CQRS.Query.CouponeGetAll
{
    public class CouponeGetAllQueryHandler : IRequestHandler<CouponeGetAllQuery, IEnumerable<CouponDto>>
    {
        private readonly ICouponeRepositoryService _couponeRepositoryService;
        public CouponeGetAllQueryHandler(ICouponeRepositoryService couponeRepositoryService)
        {
            _couponeRepositoryService = couponeRepositoryService;

        }

        public async Task<IEnumerable<CouponDto>> Handle(CouponeGetAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _couponeRepositoryService.GetAll();
            if (!result.IsSuccess)
            {
                throw new Exception($"Failed to retrieve coupons: {string.Join(", ", result.Errors.Select(e => e.Message))}");
            }
            return result.Value.ToList();
        }
    }
}