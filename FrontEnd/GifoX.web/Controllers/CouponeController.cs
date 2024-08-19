using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GifoX.web.Models.Coupon;
using GifoX.web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GifoX.web.Controllers
{
    [Route("[controller]")]
    public class CouponeController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponeController(ICouponService couponService)
        {
            _couponService = couponService;
        }



        public async Task<IActionResult> CouponeIndex()
        {
            var response = await _couponService.GetAllCouponsAsync();
            if (response != null && response.IsSuccess)
            {
                var list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result)!);
                return View(list);
            }

            return View();
        }


    }
}