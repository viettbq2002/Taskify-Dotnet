using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.Exceptions
{
    public class BadRequestException(string message): HttpResponseException(message, StatusCodes.Status400BadRequest)
    {
            
    }
}
