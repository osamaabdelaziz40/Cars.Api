using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Cars.DomainHelper.Exceptions;
using Cars.DomainHelper.Models;

namespace Cars.Api.Middleware
{
    public class JsonExceptionMiddleware
    {
        //IExceptionLogRepository _exceptionLogRepository;

        //public JsonExceptionMiddleware(IExceptionLogRepository exceptionLogRepository)
        //{
        //    _exceptionLogRepository = exceptionLogRepository;
        //}
        public async Task Invoke(HttpContext httpContext)
        {
            // Save Exception to DB 
            // Handle Business Exception --> return same message
            // Bad Request --> return status code 400 - message 'E-Retail Exception + Exception Id'
            // Default --> return Message 'E-Retail Exception + Exception Id'

            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception == null)
                return;


            string data = null;
            //if (exception.Data.Values.Any())
            //    data = string.Join(",", exception.Data.Values);
            string innerExeption = exception.InnerException != null ? exception.InnerException.Message : null;
            try
            {
                //TODO: Instead of calling DB we have to call APG.Log\LogException we are testing the exception log here only

                var exceptionLogId = 0;

                httpContext.Items["ExceptionErrorId"] = exceptionLogId;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (exception is BusinessException)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionResponse { Message = exception.Message })).ConfigureAwait(false);
                }
                else if (exception is BadRequestException)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionResponse { Message = $"APG Request Error: {exceptionLogId}" })).ConfigureAwait(false);
                }
                else
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionResponse { Message = $"APG Error: {exceptionLogId}" })).ConfigureAwait(false);
                }
                //////////Use RabitMQ To Add To ExceptionLog

            }
            catch (Exception ex)
            {
            }
        }
    }
}
