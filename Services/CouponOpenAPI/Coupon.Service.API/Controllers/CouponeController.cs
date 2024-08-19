using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Application.CQRS.Query.CouponeGetAll;
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
            var model = _mediator.Send(new CouponeGetAllQuery());
            return Ok(model);
        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<IActionResult> GetCoupone(string code)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();
        }



    }
}