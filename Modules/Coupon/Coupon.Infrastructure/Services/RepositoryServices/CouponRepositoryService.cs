using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Application.Mappers;
using Coupons.Service.Core.Request;
using Coupons.Service.Infrastructure.Repositories;
using Coupons.Service.Infrastructure.UnitOfWork;
using Coupons.Service.Core.Domain;
using Coupons.Service.Core.Dto;
using FluentResults;
using Shared.Shared.Infrastructure.UnitOfWork;
using Coupons.Service.Infrastructure.Data;

namespace Coupons.Service.Infrastructure.Services.RepositoryServices
{
    public class CouponRepositoryService : ICouponeRepositoryService
    {
        private readonly IUnitOfWork<CouponeDbContext, ICouponeRepository> _unitOfWork;

        public CouponRepositoryService(IUnitOfWork<CouponeDbContext, ICouponeRepository> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddCoupone(CouponeRequest model)
            => await Result.Try(async Task () => await AddCouponeAsync(model));
        public async Task<Result> DeleteCoupone(Guid Id)
            => await Result.Try(async Task () => await DeleteCouponeAsync(Id));
        public async Task<Result<IEnumerable<CouponDto>>> GetAll()
            => await Result.Try(async Task<IEnumerable<CouponDto>> () => await GetAllCouponeAsync());
        public async Task<Result<CouponDto>> GetByCode(string code)
            => await Result.Try(async Task<CouponDto> () => await GetByCodeCouponeAsync(code));
        public async Task<Result<CouponDto>> GetById(Guid Id)
            => await Result.Try(async Task<CouponDto> () => await GetByIdCouponeAsync(Id));
        public async Task<Result<CouponDto>> UpdateCoupone(CouponeRequest model, Guid id)
            => await Result.Try(async Task<CouponDto> () => await UpdateCouponeAsync(model, id));
        public async Task<Result<CouponDto>> UseCoupone(string code)
            => await Result.Try(async Task<CouponDto> () => await UseCouponeAsync(code));

        private async Task<CouponDto> AddCouponeAsync(CouponeRequest model)
        {
            var domain = CouponeMapper.MapCouponeRequestToCouponModel(model);

            domain = await _unitOfWork.Repository.AddCouponeAsync(domain);
            await _unitOfWork.SaveChangesAsync();

            return CouponeMapper.MapCouponModelToCouponDto(domain);
        }

        private async Task DeleteCouponeAsync(Guid Id)
        {
            await _unitOfWork.Repository.DeleteCouponeAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<IEnumerable<CouponDto>> GetAllCouponeAsync()
        {
            var model = await _unitOfWork.Repository.GetAllAsync();
            return CouponeMapper.MapCouponModelToCouponDto(model);
        }

        private async Task<CouponDto> GetByCodeCouponeAsync(string code)
        {
            var model = await _unitOfWork.Repository.GetByCodeAsync(code);
            return CouponeMapper.MapCouponModelToCouponDto(model);
        }

        private async Task<CouponDto> GetByIdCouponeAsync(Guid Id)
        {
            var model = await _unitOfWork.Repository.GetByIdAsync(Id);
            return CouponeMapper.MapCouponModelToCouponDto(model);
        }

        private async Task<CouponDto> UpdateCouponeAsync(CouponeRequest model, Guid id)
        {
            var entity = CouponeMapper.MapCouponeRequestToCouponModel(model, id);

            var result = _unitOfWork.Repository.UpdateCoupone(entity);
            await _unitOfWork.SaveChangesAsync();

            return CouponeMapper.MapCouponModelToCouponDto(result);
        }

        private async Task<CouponDto> UseCouponeAsync(string code)
        {
            var model = await _unitOfWork.Repository.GetByCodeAsync(code);
            model.UseCoupon();

            var result = _unitOfWork.Repository.UpdateCoupone(model);
            await _unitOfWork.SaveChangesAsync();

            return CouponeMapper.MapCouponModelToCouponDto(result);
        }
    }
}