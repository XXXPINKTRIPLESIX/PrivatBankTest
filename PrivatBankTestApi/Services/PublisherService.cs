using Newtonsoft.Json;
using PrivatBankTestApi.DTO;
using PrivatBankTestApi.Interfaces;
using PrivatBankTestApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivatBankTestApi.Common;

namespace PrivatBankTestApi.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IMessagePublisher _messagePublisher;

        public PublisherService(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public async Task<ExecutionResult<ByIdResponseDTO>> PublishRequestByIdMessageAsync(RequestByIdMessage message)
        {
            var body = JsonConvert.SerializeObject(message);

            var rawResponse = await Task.Run(() => _messagePublisher.ToQueue(body, "rpc_2_queue"));

            var response = JsonConvert.DeserializeObject<ExecutionResult<ByIdResponseDTO>>(rawResponse);

            return response;
        }

        public async Task<ExecutionResult<List<RequestsResponseDTO>>> PublishRequestsMessageAsync(RequestsMessage message)
        {
            var body = JsonConvert.SerializeObject(message);

            var rawResponse = await Task.Run(() => _messagePublisher.ToQueue(body, "rpc_3_queue"));
        
            var response = JsonConvert.DeserializeObject<ExecutionResult<List<RequestsResponseDTO>>>(rawResponse);
            
            return response;
        }

        public async Task<ExecutionResult<string>> PublishRequestMessageAsync(RequestMessage message)
        {
            var body = JsonConvert.SerializeObject(message);

            var rawResponse = await Task.Run(() => _messagePublisher.ToQueue(body, "rpc_queue"));

            var response = JsonConvert.DeserializeObject<ExecutionResult<string>>(rawResponse);

            return response;
        }
    }
}
