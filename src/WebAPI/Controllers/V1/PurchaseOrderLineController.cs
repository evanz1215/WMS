using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PurchaseOrderLineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrderLineController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
