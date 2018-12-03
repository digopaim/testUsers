//using Domain.Core.Validators;
//using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorHandler
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandler(RequestDelegate next) => this.next = next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //if (exception.GetType() == typeof(MediatrPipelineException))
            //{
            //    var result = JsonConvert.SerializeObject(new { success = false, error = exception.Message, Stacktrace = exception.StackTrace });

            //    var validationException = exception.InnerException as ValidationException;
            //    if (validationException != null)
            //    {
            //        var json = new JsonErrorResponse { Messages = validationException.Errors.Select(e => e.ErrorMessage).ToArray() };
            //        result = JsonConvert.SerializeObject(new { success = false, error = json, Stacktrace = exception.StackTrace });
            //    }

            //    var code = HttpStatusCode.BadRequest;
            //    context.Response.ContentType = "application/json";
            //    context.Response.StatusCode = (int)code;
            //    return context.Response.WriteAsync(result);
            //}
            
                var code = HttpStatusCode.InternalServerError; // 500 if unexpected
                var result = JsonConvert.SerializeObject(new { success = false, error = exception.Message, Stacktrace = exception.StackTrace });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                return context.Response.WriteAsync(result);
            
        }
    }

    public class JsonErrorResponse
    {
        public string[] Messages { get; set; }
    }

}
