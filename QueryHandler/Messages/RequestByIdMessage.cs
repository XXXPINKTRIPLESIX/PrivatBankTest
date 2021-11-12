using Dapper;
using QueryHandler.Config;
using QueryHandler.Data.Models;
using QueryHandler.DTO;
using QueryHandler.Interfaces;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PrivatBankTestApi.Common;

namespace QueryHandler.Messages
{
    public class RequestByIdMessage : IMessage<ExecutionResult<ByIdResponseDTO>>
    {
        public int RequestId { get; set; }

        public async Task<ExecutionResult<ByIdResponseDTO>> ExecRequestAsync()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            await using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);

            var procedure = "[SelectById]";

            var results = await sqlConnection.QueryAsync<ByIdResponseDTO>(procedure,
                new
                {
                    id = RequestId
                },
                commandType: System.Data.CommandType.StoredProcedure);
            
            if(results != null & results.Any())
                return ExecutionResult<ByIdResponseDTO>.CreateSuccessResult(results.First());

            return ExecutionResult<ByIdResponseDTO>.CreateErrorResult("Not found");
        }
    }
}
