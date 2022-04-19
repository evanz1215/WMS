using Application.ProductTypes.CreateProductType;
using Application.ProductTypes.GetProductType;
using Application.ProductTypes.GetProductTypeList;
using Application.ProductTypes.PatchProductType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetProductTypeQuery
            {
                Id = id
            });

            return Ok(result);
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductTypeCommand command)
        {
            var result = await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync([FromRoute] int id, [FromBody] JsonPatchDocument<ProductTypeForUpdateDto> patchDocument)
        {
            var result = await _mediator.Send(new PatchProductTypeCommand
            {
                Id = id,
                PatchDocument = patchDocument
            });

            return NoContent();
        }




    }
}
