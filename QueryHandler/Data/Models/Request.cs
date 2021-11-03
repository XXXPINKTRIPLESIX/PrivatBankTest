using QueryHandler.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryHandler.Data.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public RequestStatus Status { get; set; }
    }
}
