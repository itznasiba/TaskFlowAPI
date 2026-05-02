using System.ComponentModel;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Core.Exceptions;
namespace TaskAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred. TraceId:{TraceId}", context.TraceIdentifier);
                //httpContext.Response.StatusCode = 500;
                var problem = CreateProblemDetails(ex, context);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = problem.Status ?? (int)HttpStatusCode.InternalServerError;
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                await context.Response.WriteAsync(JsonSerializer.Serialize(problem, options));
            }
        }
        private ProblemDetails CreateProblemDetails(Exception ex, HttpContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred while processing your request.",
                Detail = _env.IsDevelopment() ? ex.ToString() : null,
                Status = (int)HttpStatusCode.InternalServerError
            };
            if (ex is NotFoundException)
            {
                problemDetails.Title = "Resource not found.";
                problemDetails.Status = (int)HttpStatusCode.NotFound;
            }
            else if (ex is BadRequestException)
            {
                problemDetails.Title = "Bad request.";
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
            }
            return problemDetails;
        }
    }
}
