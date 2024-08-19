using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GifoX.web.Models;
using GifoX.web.Models.Coupon;
using GifoX.web.Service.IService;
using GifoX.web.Utility;
using static GifoX.web.Utility.SD;

namespace GifoX.web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;

        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = couponDto,
                Url = $"/{CouponAPIBase}/{Services.Coupone}"
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(Guid id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = $"/{CouponAPIBase}/{Services.Coupone}/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = $"{CouponAPIBase}/{Services.Coupone}/{Operations.GetAll}",
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = $"{CouponAPIBase}/{Services.Coupone}/{Operations.GetByCode}/{couponCode}"
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(Guid id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = $"{CouponAPIBase}/{Services.Coupone}/{id}"
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = couponDto,
                Url = $"{CouponAPIBase}/{Services.Coupone}",
            });
        }
    }
}