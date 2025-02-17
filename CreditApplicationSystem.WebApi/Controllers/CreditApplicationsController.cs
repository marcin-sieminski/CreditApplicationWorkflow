﻿using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/credit-applications")]
    [Authorize]
    public class CreditApplicationsController : ApiControllerBase
    {
        private readonly ILogger<CreditApplicationsController> _logger;

        public CreditApplicationsController(IMediator mediator, ILogger<CreditApplicationsController> logger) : base(mediator)
        {
            _logger = logger;
            _logger.LogInformation("CreditApplication controller logging.");
        }

        /// <summary>
        /// Get list of all credit applications.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> GetCreditApplications([FromQuery] GetCreditApplicationsRequest request)
        {
            return HandleRequest<GetCreditApplicationsRequest, GetCreditApplicationsResponse>(request);
        }

        /// <summary>
        /// Get specific credit application by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> GetCreditApplicationById([FromRoute] int id)
        {
            return HandleRequest<GetCreditApplicationByIdRequest, GetCreditApplicationByIdResponse>(
                new GetCreditApplicationByIdRequest { Id = id });
        }

        /// <summary>
        /// Create new credit application.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddCreditApplication([FromBody] AddCreditApplicationRequest request)
        {
            return HandleRequest<AddCreditApplicationRequest, AddCreditApplicationResponse>(request);
        }

        /// <summary>
        /// Edit data of existing credit application.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> EditCreditApplication([FromBody] EditCreditApplicationRequest request)
        {
            return HandleRequest<EditCreditApplicationRequest, EditCreditApplicationResponse>(request);
        }

        /// <summary>
        /// Delete credit application.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> DeleteCreditApplication([FromBody] DeleteCreditApplicationRequest request)
        {
            return HandleRequest<DeleteCreditApplicationRequest, DeleteCreditApplicationResponse>(request);
        }
    }
}
