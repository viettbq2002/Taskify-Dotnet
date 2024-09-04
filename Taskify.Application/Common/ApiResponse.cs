using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.Common
{
    public class ApiResponse<T>
    {
        public ApiResponse(int statusCode, string message, T? data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; } = null!; 
        public T? Data { get; set; }
        public static ApiResponse<T> Success(string message, T data)
        {
            return new ApiResponse<T>(StatusCodes.Status200OK, message, data);

        }
        public static ApiResponse<T> Created(string message, T data)
        {
            return new ApiResponse<T>(StatusCodes.Status201Created, message, data);

        }

    }
}
