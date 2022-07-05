using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Common
{
    #nullable enable
    public class ExecutionResult<T> : ExecutionResult where T : class
    {
        public T Result { get; private set; }

        public static ExecutionResult<T> CreateSuccessResult(T obj)
        {
            return new ExecutionResult<T>
            {
                IsSuccess = true,
                Result = obj
            };
        }

        public static ExecutionResult<T> CreateErrorResult(string errorMessage)
        {
            return new ExecutionResult<T>
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
#nullable disable
 