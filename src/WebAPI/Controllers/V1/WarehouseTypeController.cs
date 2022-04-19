using Application.WarehouseTypes.CreateWarehouseType;
using Application.WarehouseTypes.GetWarehouseTypeList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class WarehouseTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] GetWarehouseTypeListQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateWarehouseTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return NoContent();
        }
    }
}
