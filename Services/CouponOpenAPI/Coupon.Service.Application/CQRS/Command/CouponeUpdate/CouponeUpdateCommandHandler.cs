using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Dto;
using Coupons.Service.Infrastructure.Services.RepositoryServices;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeUpdate
{
    public class CouponeUpdateCommandHandler : IRequestHandler<CouponeUpdateCommand, CouponDto>
    {
        private readonly ICouponeRepositoryService _couponeRepository;
        public CouponeUpdateCommandHandler(ICouponeRepositoryService couponeRepository)
        {
            _couponeRepository = couponeRepository;

        }
        public async Task<CouponDto> Handle(CouponeUpdateCommand request, CancellationToken cancellationToken)
        {
            var model = await _couponeRepository.UpdateCoupone(request.CouponeRequest, request.Id);
            if (!model.IsSuccess)
            {
                throw new Exception($"Coupone update was Failed, errors: {string.Join(", ", model.Errors.Select(x => x.Message))}");
            }
            return model.Value;
        }
    }
}