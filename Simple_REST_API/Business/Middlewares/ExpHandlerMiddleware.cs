using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Simple_REST_API.Domain.Responses.Exceptions;
using System.Net;

namespace Simple_REST_API.Business.Middlewares
{
    public class ExpHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ExpHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception)
            {
                ExpDetails problemDetails = new ExpDetails { 
                    Title = "Something bad happened internally.Please try again.", StatusCode= StatusCodes.Status500InternalServerError };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError ;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}));

            }
        }
    }
}
