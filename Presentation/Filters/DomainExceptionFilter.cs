using InventoryHub.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InventoryHub.Presentation.Filters;

public class DomainExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainException domainException)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Erro de regra de negócio",
                Detail = domainException.Message,
                Status = context.Exception switch
                {
                    ProductNotFoundException => StatusCodes.Status404NotFound,
                    InsufficientStockException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status400BadRequest
                },
                Type = domainException.GetType().Name
            };

            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };
            context.ExceptionHandled = true;
        }
    }
}
