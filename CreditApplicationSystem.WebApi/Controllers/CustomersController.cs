﻿using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromQuery] GetCustomersRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var request = new GetCustomerByIdRequest()
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
