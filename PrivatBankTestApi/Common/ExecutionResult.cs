using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Common
{
    #nullable enable
    public class ExecutionResult<T> where T : class?
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
    #nullable disable
}
 