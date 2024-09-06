using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.Exceptions
{
    public class BadRequestException: HttpResponseException
    {
        public IDictionary<string, string[]>? ValidationErrors { get; set; }

        public BadRequestException(string message) : base(message, statusCode: StatusCodes.Status400BadRequest) { 

        }

        public BadRequestException(string message, ValidationResult validationResult) : base(message, statusCode: StatusCodes.Status400BadRequest)
        {
            ValidationErrors = validationResult.ToDictionary();

        }




    }
}
