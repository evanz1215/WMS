using Application.Units.CreateUnit;
using Application.Units.GetUnit;
using Application.Units.GetUnitList;
using Application.Units.PatchUnit;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] GetUnitListQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {

            var result = await _mediator.Send(new GetUnitQuery
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUnitCommand command)
        {
            var result = await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync([FromRoute] int id, [FromBody] JsonPatchDocument<UnitForUpdateDto> patchDocument)
        {

            var result = await _mediator.Send(new PatchUnitCommand
            {
                Id = id,
                PatchDocument = patchDocument
            });

            return NoContent();
        }
    }
}