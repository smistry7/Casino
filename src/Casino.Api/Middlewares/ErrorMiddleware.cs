using Casino.Api.Exceptions;
using FluentValidation;
using Newtonsoft.Json;
using System.Net;

namespace Casino.Api.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //todo: add logging
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException e)
            {
                await ErrorResponse(httpContext, HttpStatusCode.NotFound, e.Message);
            }
            catch(BadRequestException e)
            {
                await ErrorResponse(httpContext, HttpStatusCode.BadRequest, e.Message);
            }
            catch(ValidationException e)
            {
                await ErrorResponse(httpContext, HttpStatusCode.BadRequest, string.Join(".", e.Errors));
            }
            catch (Exception e)
            {
                await ErrorResponse(httpContext, HttpStatusCode.InternalServerError, "An unhandled error occurred");
            }
        }

        private async Task ErrorResponse(HttpContext context, HttpStatusCode statusCode, string? message)
        {
            var response = new
            {
                StatusCode = statusCode,
                Message = message
            };
            var jsonResponse = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
