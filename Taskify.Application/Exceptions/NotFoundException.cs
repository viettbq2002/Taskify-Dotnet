using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.Exceptions
{
    public class NotFoundException(string message): HttpResponseException(message,StatusCodes.Status404NotFound)
    {

    }
}
