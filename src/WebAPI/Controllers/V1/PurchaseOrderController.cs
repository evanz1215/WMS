using Application.PurchaseOrders.CreatePurchaseOrder;
using Application.PurchaseOrders.GetPurchaseOrderList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
