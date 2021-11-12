using PrivatBankTestApi.DTO;
using PrivatBankTestApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivatBankTestApi.Common;

namespace PrivatBankTestApi.Interfaces
{
    public interface IPublisherService : IService
    {
        Task<ExecutionResult<ByIdResponseDTO>> PublishRequestByIdMessageAsync(RequestByIdMessage message);
        Task<ExecutionResult<List<RequestsResponseDTO>>> PublishRequestsMessageAsync(RequestsMessage message);
        Task<ExecutionResult<string>> PublishRequestMessageAsync(RequestMessage message);
    }
}
