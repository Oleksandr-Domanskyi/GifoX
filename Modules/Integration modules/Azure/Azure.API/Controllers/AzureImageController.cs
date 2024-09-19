using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.ProductShared.Dto;

namespace Azure.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AzureImageController : ControllerBase
    {
        public AzureImageController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetImage()
        {
            return Ok();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdImage(Guid Id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> SaveImage(ImageDto imageDto)
        {
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteImage(Guid Id)
        {
            return Ok();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateImage(Guid Id)
        {
            return Ok();
        }
    }
}
