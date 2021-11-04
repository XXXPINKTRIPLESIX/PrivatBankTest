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

namespace QueryHandler.Messages
{
    public class RequestsMessage : IMessage<IEnumerable<RequestsResponseDTO>>
    {
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }

        public async Task<IEnumerable<RequestsResponseDTO>> ExecRequestAsync()
        {
            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);

            var procedure = "[SelectByIdAndAddress]";

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var results = await sqlConnection.QueryAsync<RequestsResponseDTO>(procedure,
                new
                {
                    client_id = ClientId,
                    department_address = DepartmentAddress
                },
                commandType: System.Data.CommandType.StoredProcedure);

            return results;
        }
    }
}
