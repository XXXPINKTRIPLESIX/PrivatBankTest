using Dapper;
using QueryHandler.Config;
using QueryHandler.Data.Models;
using QueryHandler.DTO;
using QueryHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PrivatBankTestApi.Common;

namespace QueryHandler.Messages
{
    public class RequestsMessage : IMessage<ExecutionResult<IEnumerable<RequestsResponseDTO>>>
    {
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }

        public async Task<ExecutionResult<IEnumerable<RequestsResponseDTO>>> ExecRequestAsync()
        {
            await using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);

            var procedure = "[SelectByIdAndAddress]";

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var results = await sqlConnection.QueryAsync<RequestsResponseDTO>(procedure,
                new
                {
                    client_id = ClientId,
                    department_address = DepartmentAddress
                },
                commandType: System.Data.CommandType.StoredProcedure);

            if(results != null & results.Any())
                return ExecutionResult<IEnumerable<RequestsResponseDTO>>.CreateSuccessResult(results);

            return ExecutionResult<IEnumerable<RequestsResponseDTO>>.CreateErrorResult("Not found");
        }
    }
}