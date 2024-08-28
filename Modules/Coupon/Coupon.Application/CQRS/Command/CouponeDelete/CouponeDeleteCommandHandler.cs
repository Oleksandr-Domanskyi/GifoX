using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Infrastructure.Services.RepositoryServices;
using MediatR;

namespace Coupon.Service.Application.CQRS.Command.CouponeDelete
{
    public class CouponeDeleteCommandHandler : IRequestHandler<CouponeDeleteCommand>
    {
        private readonly ICouponeRepositoryService _couponeRepository;
        public CouponeDeleteCommandHandler(ICouponeRepositoryService couponeRepository)
        {
            _couponeRepository = couponeRepository;
        }
        public async Task Handle(CouponeDeleteCommand request, CancellationToken cancellationToken)
        {
            var model = await _couponeRepository.DeleteCoupone(request.Id);
            if (!model.IsSuccess)
            {
                throw new Exception($"Coupone Delete was Failed, errors: {string.Join(", ", model.Errors.Select(x => x.Message))}");
            }
            return;
        }
    }
}