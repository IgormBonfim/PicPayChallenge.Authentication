using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception.InnerException ?? context.Exception;

            if (exception is HttpException)
            {
                HttpException httpException = exception as HttpException;
                context.HttpContext.Response.StatusCode = (int)httpException.StatusCode;
                context.Result = new ObjectResult(new 
                {
                    Message = exception.Message,
                    Type = exception.GetType().Name
                });
            }
            return;
        }
    }
}
