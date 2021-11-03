using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Common
{
    public class ErrorResult
    {
        public string Code { get; private set; }
        public string Message { get; private set; }

        public ErrorResult(string code, string message)
        {
            Message = message;
            Code = code;
        }
    }
}
 