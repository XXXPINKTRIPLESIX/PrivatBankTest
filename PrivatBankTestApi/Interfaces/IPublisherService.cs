using PrivatBankTestApi.DTO;
using PrivatBankTestApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Interfaces
{
    public interface IPublisherService : IService
    {
        Task<ByIdResponseDTO> PublishRequestByIdMessageAsync(RequestByIdMessage message);
        Task<List<RequestsResponseDTO>> PublishRequestsMessageAsync(RequestsMessage message);
        Task<int?> PublishRequestMessageAsync(RequestMessage message);
    }
}
