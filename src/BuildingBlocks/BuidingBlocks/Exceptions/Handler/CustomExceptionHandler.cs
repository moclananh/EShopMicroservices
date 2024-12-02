using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuidingBlocks.Exceptions.Handler
{
    public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
           logger.LogError("Error Message: {exceptionMessage}, Time of occurence {time}",
               exception.Message, DateTime.UtcNow);

            (string Details, string Title, int StatusCode) details = exception switch
            {
                InternalServerException =>
                (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError
                ),
                ValidationException => (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status400BadRequest
                ),
                BadRequestException => (
                   exception.Message,
                   exception.GetType().Name,
                   context.Response.StatusCode = StatusCodes.Status400BadRequest
               ),
                NotFoundException => (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status404NotFound
                ),
                // defaut exception
                _ => (
                   exception.Message,
                   exception.GetType().Name,
                   context.Response.StatusCode = StatusCodes.Status500InternalServerError
               )
            };

            var problemDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Details,
                Status = details.StatusCode,
                Instance = context.Request.Path
            };

            problemDetails.Extensions.Add("tradeId", context.TraceIdentifier);
            if (exception is ValidationException validationException)
            {
                problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
            }
            
            await context.Response.WriteAsJsonAsync( problemDetails, cancellationToken : cancellationToken );
            return true;
        }
    }
}
