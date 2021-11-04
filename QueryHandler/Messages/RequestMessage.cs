using Dapper;
using QueryHandler.Config;
using QueryHandler.Enums;
using QueryHandler.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QueryHandler.Messages
{
    public class RequestMessage : IMessage<int>
    {
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.InProgress;

        public async Task<int> ExecRequestAsync()
        {
            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);

            var procedure = "[InsertRequest]";
            var _status = Status.ToString();
            var results = await sqlConnection.QueryAsync<int>(procedure,
                new
                {
                    client_id = ClientId,
                    department_address = DepartmentAddress,
                    currency = Currency,
                    status = Status.ToString(),
                    amount = Amount
                },
                commandType: System.Data.CommandType.StoredProcedure);

            return results.First();
        }
    }
}
