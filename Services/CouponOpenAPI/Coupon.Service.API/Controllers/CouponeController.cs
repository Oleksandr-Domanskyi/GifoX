using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupon.Service.Application.CQRS.Command.CouponeCreate;
using Coupon.Service.Application.CQRS.Command.CouponeDelete;
using Coupon.Service.Application.CQRS.Command.CouponeUpdate;
using Coupon.Service.Application.CQRS.Command.CouponeUse;
using Coupon.Service.Application.CQRS.Query.CouponeGetByCode;
using Coupon.Service.Application.CQRS.Query.CouponeGetById;
using Coupons.Service.Application.CQRS.Query.CouponeGetAll;
using Coupons.Service.Core.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coupons.Service.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CouponeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var model = await _mediator.Send(new CouponeGetAllQuery());

            return Ok(new
            {
                Result = model,
                IsSuccess = true,
                Message = ""
            });
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<IActionResult> GetCoupone(string code)
        {
            var model = await _mediator.Send(new CouponeGetByCodeQuery(code));
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _mediator.Send(new CouponeGetByIdQuery(id));
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupone([FromBody] CouponeRequest couponeRequest)
        {
            await _mediator.Send(new CouponeCreateCommand(couponeRequest));
            return Ok(new
            {
                Result = "",
                IsSuccess = true,
                Message = "Was Created Successfully!!!",
            });
        }

        [HttpPut]
        [Route("UseCupone/{code}")]
        public async Task<IActionResult> UseCoupone(string code)
        {
            var model = await _mediator.Send(new CouponeUseCommand(code));
            return Ok(new
            {
                Message = $"Coupon {model.CouponCode} was Used!!!",
                Data = model
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCoupone([FromBody] CouponeRequest couponeRequest, Guid id)
        {
            var model = await _mediator.Send(new CouponeUpdateCommand(couponeRequest, id));
            return Ok(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCoupone(Guid id)
        {
            await _mediator.Send(new CouponeDeleteCommand(id));
            return Ok(new
            {
                Result = "",
                IsSuccess = true,
                Message = "Was Deleted Successfully!!!",
            });
        }




    }
}