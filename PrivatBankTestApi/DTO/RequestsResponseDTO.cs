using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivatBankTestApi.Enums;

namespace PrivatBankTestApi.DTO
{
    public class RequestsResponseDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public RequestStatus Status { get; set; }
    }
}
