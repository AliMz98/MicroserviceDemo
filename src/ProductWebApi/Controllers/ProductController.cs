using ProductWebApi.Application.Commands;
using ProductWebApi.Application.Interfaces;
using ProductWebApi.Application.Models;
using ProductWebApi.Application.Queries;
using ProductWebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebApi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMediator _mediator;

        public ProductController(IProductRepository ProductRepository, IMediator mediator)
        {
            _ProductRepository = ProductRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await  _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var result = await _mediator.Send(new CreateProductCommand (dto));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto dto)
        {
            await _mediator.Send(new UpdateProductCommand(dto));
            return Ok();
        }
    }
}
