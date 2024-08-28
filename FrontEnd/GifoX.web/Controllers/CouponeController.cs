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
            if (response!.IsSuccess)
            {
                var list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result)!);
                return View(list);
            }
            throw new Exception($"Get All coupone errors: {response.Message}");
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCoupone(Guid id)
        {
            var response = await _couponService.DeleteCouponAsync(id);
            if (response!.IsSuccess)
            {
                return RedirectToAction("CouponeIndex");
            }
            throw new Exception($"Delete errors: {response.Message}");
        }

        [HttpGet("Create")]
        public IActionResult CouponeCreate()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCoupon(CouponeRequest couponeRequest)
        {
            var response = await _couponService.CreateCouponAsync(couponeRequest);
            if (response!.IsSuccess)
            {
                return RedirectToAction("CouponeIndex");
            }
            throw new Exception(response.Message);
        }
        [HttpGet("Update/{id}")]
        public async Task<IActionResult> CouponeUpdate(Guid id)
        {
            var response = await _couponService.GetCouponByIdAsync(id);
            if (response!.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result)!);
                return View(data);
            }
            throw new Exception($"Update view errors: {response.Message}");
        }
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateCoupon(Guid id, CouponeRequest couponeRequest)
        {
            var response = await _couponService.UpdateCouponAsync(id, couponeRequest);
            if (response!.IsSuccess)
            {
                return RedirectToAction("CouponeIndex");
            }
            throw new Exception($"Update model errors: {response.Message}");
        }


    }
}