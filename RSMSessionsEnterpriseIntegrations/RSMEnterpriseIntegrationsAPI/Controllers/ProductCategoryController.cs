namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _service;

        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("Get")]        
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            return Ok(await _service.GetProductCategoryById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteProductCategory(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductCategoryDto dto)
        {
            return Ok(await _service.CreateProductCategory(dto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductCategoryDto dto)
        {
            return Ok(await _service.UpdateProductCategory(dto));
        }
    }
}
