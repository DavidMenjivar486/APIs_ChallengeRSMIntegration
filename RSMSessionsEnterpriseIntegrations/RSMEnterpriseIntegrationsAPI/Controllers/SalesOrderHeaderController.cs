namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderHeaderController : ControllerBase
    {
        private readonly ISalesOrderHeaderService _service;

        public SalesOrderHeaderController(ISalesOrderHeaderService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get(int pageNumber, int pageSize)
        {
            return Ok(await _service.GetAll(pageNumber, pageSize));
        }

        [HttpGet("Get")]        
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            return Ok(await _service.GetSalesOrderHeaderById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteSalesOrderHeader(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateSalesOrderHeaderDto dto)
        {
            return Ok(await _service.CreateSalesOrderHeader(dto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateSalesOrderHeaderDto dto)
        {
            return Ok(await _service.UpdateSalesOrderHeader(dto));
        }
    }
}