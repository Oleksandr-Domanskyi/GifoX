using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GifoX.web.Service;
using GifoX.web.Service.IService;
using GifoX.web.Utility;

namespace GifoX.web.Extentions
{
    public static class CouponExtention
    {
        public static void AddCouponExtention(this IServiceCollection services, IConfiguration configuration)
        {
            SD.CouponAPIBase = configuration.GetSection("ServicesUrls:CouponAPI").Value!;

            services.AddHttpClient<ICouponService, CouponService>();

            services.AddScoped<ICouponService, CouponService>();
        }
    }
}