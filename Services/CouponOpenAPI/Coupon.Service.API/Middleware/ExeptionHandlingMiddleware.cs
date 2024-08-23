using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;
using FluentResults;

namespace Coupon.Service.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var response = new
            {
                Message = "An unexpected error occurred.",
                Errors = new List<string>(),
                IsSuccess = false
            };
            switch (exception)
            {
                case FluentValidation.ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    response = new
                    {
                        Message = "Validation Failed",
                        Errors = validationException.Errors.Select(e => e.ErrorMessage).ToList(),
                        IsSuccess = false
                    };
                    break;

                case KeyNotFoundException:
                    code = HttpStatusCode.NotFound;
                    response = new
                    {
                        Message = "Resource not found.",
                        Errors = new List<string>(),
                        IsSuccess = false,
                    };
                    break;

                case UnauthorizedAccessException:
                    code = HttpStatusCode.Forbidden;
                    response = new
                    {
                        Message = "Access denied. You do not have the necessary permissions.",
                        Errors = new List<string>(),
                        IsSuccess = false,
                    };
                    break;

                default:
                    response = new
                    {
                        Message = "An unexpected error occurred.",
                        Errors = new List<string> { exception.Message },
                        IsSuccess = false
                    };
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }
    }
}
