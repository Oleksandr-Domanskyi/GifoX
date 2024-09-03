using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.CQRS.Commands.ProductApplyCoupon;
using Product.Application.CQRS.Commands.ProductCreate;
using Product.Application.CQRS.Commands.ProductDelete;
using Product.Application.CQRS.Commands.ProductUpdate;
using Product.Application.CQRS.Queries.ProductGetAll;
using Product.Application.CQRS.Queries.ProductGetById;
using Product.Service.Core.ProductDto.Request;

namespace Product.Service.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _mediator.Send(new ProductGetAllQuery());
            return Ok(model);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _mediator.Send(new ProductGetByIdQuery(id));
            return Ok(model);
        }
        [HttpGet("{Id}/apply-coupon")]
        public async Task<IActionResult> ApplyCoupone(Guid Id, string couponCode)
        {
            var model = await _mediator.Send(new ProductApplyCouponCommand(Id, couponCode));
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productRequest)
        {
            var model = await _mediator.Send(new ProductCreateCommand(productRequest));
            return Ok(model);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductRequest productRequest, Guid Id)
        {
            var model = await _mediator.Send(new ProductUpdateCommand(productRequest, Id));
            return Ok(model);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _mediator.Send(new ProductDeleteCommand(id));
            return Ok();
        }

    }
}