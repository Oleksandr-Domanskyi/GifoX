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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                Message = "Get All success"
            });
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<IActionResult> GetCoupone(string code)
        {
            var model = await _mediator.Send(new CouponeGetByCodeQuery(code));
            return Ok(new
            {
                Result = model,
                IsSuccess = true,
                Message = "Was Found Successfully!!!"
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _mediator.Send(new CouponeGetByIdQuery(id));
            return Ok(new
            {
                Result = model,
                IsSuccess = true,
                Message = "Was Found Successfully!!!"
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupone([FromBody] CouponeCreateCommand command)
        {
            await _mediator.Send(command);
            return Ok(new
            {
                Result = "",
                IsSuccess = true,
                Message = "Coupon created successfully!"
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
            var command = new CouponeUpdateCommand(couponeRequest, id);
            var model = await _mediator.Send(command);
            return Ok(new
            {
                Result = model,
                IsSuccess = true,
                Message = $"Coupon {model.CouponCode} was Updated successfully."
            });
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