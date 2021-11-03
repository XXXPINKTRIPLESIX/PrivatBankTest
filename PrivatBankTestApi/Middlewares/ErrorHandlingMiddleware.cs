using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PrivatBankTestApi.Exceptions;
using PrivatBankTestApi.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PrivatBankTestApi.Common;

namespace PrivatBankTestApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
		private readonly RequestDelegate _next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			var code = HttpStatusCode.InternalServerError;
			var errorMessage = ex.Message;

			var result = JsonConvert.SerializeObject(new ErrorResult(code.ToString(), errorMessage));
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			return context.Response.WriteAsync(result);
		}
	}
}
