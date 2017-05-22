using ReturnCustomErrorResponse.Extensions;
using ReturnCustomErrorResponse.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ReturnCustomErrorResponse.Attributes
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exceptions = actionExecutedContext.Exception.FromHierarchy(ex => ex.InnerException);
            var request = actionExecutedContext.ActionContext.Request;

            actionExecutedContext.Response = request.CreateResponse(HttpStatusCode.InternalServerError, new ErrorResponse
            {
                Message = String.Join(" -> ", exceptions.Select(ex => ex.Message))
            });
        }
    }
}