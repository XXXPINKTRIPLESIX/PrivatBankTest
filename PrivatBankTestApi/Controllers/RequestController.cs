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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRequestById([FromRoute] RequestByIdMessage message)
        {
            var response = await _messagePublisher.PublishRequestByIdMessageAsync(message);

            if (response == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("GetRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRequestByIdAndAddress([FromBody] RequestsMessage message)
        {
            var response = await _messagePublisher.PublishRequestsMessageAsync(message);

            if (response == null || response.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("SaveRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveRequest([FromBody] RequestMessage message)
        {
            var response = await _messagePublisher.PublishRequestMessageAsync(message);

            if (response == null)
                return StatusCode(StatusCodes.Status400BadRequest);

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
