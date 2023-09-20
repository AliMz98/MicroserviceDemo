using CustomerWebApi.Application.Commands;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Application.Models;
using CustomerWebApi.Application.Queries;
using CustomerWebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public CustomerController(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await  _mediator.Send(new DeleteCustomerCommand(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
        {
            var result = await _mediator.Send(new CreateCustomerCommand (dto));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto dto)
        {
            await _mediator.Send(new UpdateCustomerCommand(dto));
            return Ok();
        }
    }
}
