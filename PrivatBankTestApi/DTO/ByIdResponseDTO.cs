using PrivatBankTestApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.DTO
{
    public class ByIdResponseDTO
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public RequestStatus Status { get; set; }
    }
}
