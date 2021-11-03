using Newtonsoft.Json;
using PrivatBankTestApi.DTO;
using PrivatBankTestApi.Interfaces;
using PrivatBankTestApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IMessagePublisher _messagePublisher;

        public PublisherService(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public async Task<ByIdResponseDTO> PublishRequestByIdMessageAsync(RequestByIdMessage message)
        {
            var body = JsonConvert.SerializeObject(message);

            var rawResponse = await Task.Run(() => { return _messagePublisher.ToQueue(body, "rpc_2_queue"); });

            ByIdResponseDTO response = JsonConvert.DeserializeObject<ByIdResponseDTO>(rawResponse);

            return response;
        }

        public async Task<List<RequestsResponseDTO>> PublishRequestsMessageAsync(RequestsMessage message)
        {
            var body = JsonConvert.SerializeObject(message);

            var rawResponse = await Task.Run(() => { return _messagePublisher.ToQueue(body, "rpc_3_queue"); });

            List<RequestsResponseDTO> response = JsonConvert.DeserializeObject<List<RequestsResponseDTO>>(rawResponse);

            return response;
        }

        public async Task<int?> PublishRequestMessageAsync(RequestMessage message)
        {
            var body = JsonConvert.SerializeObject(message);

            var rawResponse = await Task.Run(() => { return _messagePublisher.ToQueue(body, "rpc_queue"); });

            int? response = JsonConvert.DeserializeObject<int?>(rawResponse);

            return response;
        }
    }
}
