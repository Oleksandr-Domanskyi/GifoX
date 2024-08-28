using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Product.Service.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct()
        {
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            return Ok();
        }
    }
}