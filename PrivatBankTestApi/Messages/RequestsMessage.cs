using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Messages
{
    public class RequestsMessage
    {
        public string ClientId { get; set; }
        public string DepartmentAddress { get; set; }
    }
}
