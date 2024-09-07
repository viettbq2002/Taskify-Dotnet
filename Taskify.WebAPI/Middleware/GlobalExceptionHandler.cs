using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Taskify.Application.Exceptions;

namespace Taskify.WebAPI.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occurred: {message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred while processing your request.",
                Detail = exception.Message,
                Status = exception switch
                {
                    HttpResponseException responseException => responseException.StatusCode,
                    _ => StatusCodes.Status500InternalServerError
                }
            };

            httpContext.Response.ContentType = "application/json";

            // Check if it's a BadRequestException and include validation errors if present
            if (exception is BadRequestException badRequestException && badRequestException.ValidationErrors != null)
            {
                var validationProblemDetails = new ValidationProblemDetails(badRequestException.ValidationErrors)
                {
                    Title = "Validation Error",
                    Detail = badRequestException.Message,
                    Status = StatusCodes.Status400BadRequest
                };

                httpContext.Response.StatusCode = validationProblemDetails.Status.Value;
                await httpContext.Response.WriteAsJsonAsync(validationProblemDetails, cancellationToken);
            }
            else
            {
                // Write the default ProblemDetails if it's not a validation error
                httpContext.Response.StatusCode = problemDetails.Status.Value;
                await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            }

            return true;
        }
    }
}
