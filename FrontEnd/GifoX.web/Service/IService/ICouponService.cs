using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GifoX.web.Models;
using GifoX.web.Models.Coupon;

namespace GifoX.web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(Guid id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(Guid id);

    }
}