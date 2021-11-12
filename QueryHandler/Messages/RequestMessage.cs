using Dapper;
using QueryHandler.Config;
using QueryHandler.Enums;
using QueryHandler.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PrivatBankTestApi.Common;

namespace QueryHandler.Messages
{
    public class RequestMessage : IMessage<ExecutionResult<string>>
    {
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.InProgress;

        public async Task<ExecutionResult<string>> ExecRequestAsync()
        {
            await using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);

            var procedure = "[InsertRequest]";
            
            var results = await sqlConnection.QueryAsync<int?>(procedure,
                new
                {
                    client_id = ClientId,
                    department_address = DepartmentAddress,
                    currency = Currency,
                    status = Status.ToString(),
                    amount = Amount
                },
                commandType: System.Data.CommandType.StoredProcedure);
                
            if(results != null & results.Any())
                return ExecutionResult<string>.CreateSuccessResult(results.First().ToString());

            return ExecutionResult<string>.CreateErrorResult("Bad request");
        }
    }
}
