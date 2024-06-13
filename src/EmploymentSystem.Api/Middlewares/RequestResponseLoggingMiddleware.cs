using EmploymentSystem.Application.Interfaces;
using Serilog;
using System.Text;

namespace EmploymentSystem.Api.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request
            await LogRequestAsync(context);

            // Copy the original response body stream
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                // Log the response
                await LogResponseAsync(context);

                // Copy the contents of the new memory stream (which contains the response) to the original stream
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task LogRequestAsync(HttpContext context)
        {
            var request = context.Request;
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;

            _logger.LogInfo($"HTTP Request Information:{Environment.NewLine}" +
                            $"Schema:{request.Scheme} " +
                            $"Host: {request.Host} " +
                            $"Path: {request.Path} " +
                            $"QueryString: {request.QueryString} " +
                            $"Request Body: {bodyAsText}");
        }

        private async Task LogResponseAsync(HttpContext context)
        {
            var response = context.Response;
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInfo($"HTTP Response Information:{Environment.NewLine}" +
                            $"Schema:{context.Request.Scheme} " +
                            $"Host: {context.Request.Host} " +
                            $"Path: {context.Request.Path} " +
                            $"QueryString: {context.Request.QueryString} " +
                            $"Response Body: {text}");
        }
    }
}
