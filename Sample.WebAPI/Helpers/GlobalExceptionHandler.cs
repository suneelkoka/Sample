﻿using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Sample.WebAPI.Helpers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            // Retrive Exception message  
            var errorMessage = context.Exception.Message;
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    Message = errorMessage
                });
            response.Headers.Add("X-Error", errorMessage);
            context.Result = new ResponseMessageResult(response);
        }
    }
}