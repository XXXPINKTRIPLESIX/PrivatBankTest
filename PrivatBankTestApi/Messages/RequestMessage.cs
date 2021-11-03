using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Messages
{
    public class RequestMessage
    {
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
