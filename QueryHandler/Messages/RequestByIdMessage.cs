using Dapper;
using QueryHandler.Config;
using QueryHandler.Data.Models;
using QueryHandler.DTO;
using QueryHandler.Interfaces;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QueryHandler.Messages
{
    public class RequestByIdMessage : IMessage<ByIdResponseDTO>
    {
        public int RequestId { get; set; }

        public async Task<ByIdResponseDTO> ExecRequestAsync()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);

            var procedure = "[SelectById]";

            var results = await sqlConnection.QueryAsync<ByIdResponseDTO>(procedure,
                new
                {
                    id = RequestId
                },
                commandType: System.Data.CommandType.StoredProcedure);
            return results.First();
        }
    }
}
