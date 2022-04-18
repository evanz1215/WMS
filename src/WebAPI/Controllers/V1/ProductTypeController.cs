using Application.ProductTypes.GetProductTypeList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] GetProductTypeListQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
