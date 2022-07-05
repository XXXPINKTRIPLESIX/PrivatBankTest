using QueryHandler.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryHandler.DTO
{
    public class RequestsResponseDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public RequestStatus Status { get; set; }
    }
}