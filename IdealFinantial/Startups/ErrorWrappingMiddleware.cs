using System;
using System.Linq;
using System.Threading.Tasks;
using Borrower.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IdealFinantial.Startups
{
    //https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;
        private static readonly int[] NoContentStatuses = { StatusCodes.Status204NoContent, StatusCodes.Status304NotModified };

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            string developerMessage = null;
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                developerMessage = Convert.ToString(ex);
                _logger.LogError(ex, developerMessage);

                context.Response.StatusCode = 500;
            }

            var statusCode = context.Response.StatusCode;
            if (!context.Response.HasStarted && !NoContentStatuses.Contains(statusCode))
            {
                context.Response.ContentType = "application/json";

                var response = new ErrorInfo
                {
                    Status = statusCode,
                    DeveloperMessage = developerMessage,
                };

                var json = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}