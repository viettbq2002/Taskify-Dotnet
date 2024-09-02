using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.Exceptions
{
    public class HttpResponseException(string? message, int statusCode) : Exception(message)
    {
        public int StatusCode { get; set; } = statusCode;
    }
}
