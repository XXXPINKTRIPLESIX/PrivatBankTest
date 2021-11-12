using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrivatBankTestApi.Messages;
using PrivatBankTestApi.Interfaces;
using PrivatBankTestApi.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivatBankTestApi.DTO;
using Microsoft.AspNetCore.Http;
using PrivatBankTestApi.Common;

namespace PrivatBankTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IPublisherService _messagePublisher;

        public RequestController(IPublisherService publisherService)
        {
            _messagePublisher = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{RequestId}")]
        [ProducesResponseType(typeof(ExecutionResult<ByIdResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult<ByIdResponseDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRequestById([FromRoute] RequestByIdMessage message)
        {
            var response = await _messagePublisher.PublishRequestByIdMessageAsync(message);

            return response.IsSuccess
                ? StatusCode(StatusCodes.Status200OK, response.Result)
                : StatusCode(StatusCodes.Status404NotFound, response.ErrorMessage);
        }

        [HttpPost]
        [Route("GetRequests")]
        [ProducesResponseType(typeof(ExecutionResult<List<RequestsResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult<List<RequestsResponseDTO>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRequestByIdAndAddress([FromBody] RequestsMessage message)
        {
            var response = await _messagePublisher.PublishRequestsMessageAsync(message);

            return response.IsSuccess
                ? StatusCode(StatusCodes.Status200OK, response.Result)
                : StatusCode(StatusCodes.Status404NotFound, response.ErrorMessage);
        }

        [HttpPost]
        [Route("SaveRequest")]
        [ProducesResponseType(typeof(ExecutionResult<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveRequest([FromBody] RequestMessage message)
        {
            var response = await _messagePublisher.PublishRequestMessageAsync(message);
            
            return response.IsSuccess
                ? StatusCode(StatusCodes.Status200OK, response.Result)
                : StatusCode(StatusCodes.Status400BadRequest, response.ErrorMessage);
        }
    }
}
