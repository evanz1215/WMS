using Application.PurchaseOrders.CreatePurchaseOrder;
using Application.PurchaseOrders.GetPurchaseOrderList;
using Application.PurchaseOrders.PatchPurchaseOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] GetPurchaseOrderListQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePurchaseOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync([FromRoute] Guid id, [FromBody] JsonPatchDocument<PurchaseOrderForUpdateDto> patchDocument)
        {
            var result = await _mediator.Send(new PatchPurchaseOrderCommand
            {
                Id = id,
                PatchDocument = patchDocument
            });

            return NoContent();
        }
    }


}
