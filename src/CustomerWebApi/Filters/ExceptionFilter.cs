using CustomerWebApi.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CustomerWebApi.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            if(type == typeof(NotFoundExcetion))
            {
                var exception = (NotFoundExcetion)context.Exception;
                context.Result = new NotFoundObjectResult(new
                {
                    Message = exception.Message
                });
                context.ExceptionHandled = true;
            }
            else if (type == typeof(CustomValidationException))
            {
                var exception = (CustomValidationException)context.Exception;
                context.Result = new BadRequestObjectResult(new
                {
                    Errors = exception.Errors
                });
                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Message = "unhandled error occured in server"
                });
            }

        }
    }
}
