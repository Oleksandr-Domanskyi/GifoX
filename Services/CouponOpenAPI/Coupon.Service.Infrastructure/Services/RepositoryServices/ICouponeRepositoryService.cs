using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Request;
using Coupons.Service.Core.Dto;
using FluentResults;
using Microsoft.EntityFrameworkCore.Query;

namespace Coupons.Service.Infrastructure.Services.RepositoryServices
{
    public interface ICouponeRepositoryService
    {
        Task<Result<IEnumerable<CouponDto>>> GetAll();
        Task<Result<CouponDto>> GetById(Guid Id);
        Task<Result<CouponDto>> GetByCode(string code);
        Task<Result> AddCoupone(CouponeRequest model);
        Task<Result<CouponDto>> UpdateCoupone(CouponeRequest model, Guid id);
        Task<Result> DeleteCoupone(Guid Id);
    }
}