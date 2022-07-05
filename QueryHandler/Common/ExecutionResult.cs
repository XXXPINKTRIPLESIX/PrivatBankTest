namespace PrivatBankTestApi.Common
{
    public class ExecutionResult
    {
        public bool IsSuccess { get; protected set; }
        public string ErrorMessage { get; protected set; }

        public static ExecutionResult CreateSuccessResult()
        {
            return new ExecutionResult
            {
                IsSuccess = true
            };
        }

        public static ExecutionResult CreateErrorResult(string errorMessage)
        {
            return new ExecutionResult
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
    }
}