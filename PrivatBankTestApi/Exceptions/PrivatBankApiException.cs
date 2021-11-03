using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Exceptions
{
    public class PrivatBankApiException : Exception
    {
        public PrivatBankApiException(string message) : base(message)
        {

        }
    }
}
