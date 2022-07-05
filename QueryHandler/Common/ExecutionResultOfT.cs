using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Common
{
    #nullable enable
    public class ExecutionResult<T> where T : class
    {
        public bool IsSuccess { get; private set; }
        public T Result { get; private set; }
        public string ErrorMessage { get; private set; }

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
 