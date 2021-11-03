using QueryHandler.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QueryHandler.DTO
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
