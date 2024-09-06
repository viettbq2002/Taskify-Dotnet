using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.Item;
using Taskify.Application.Interfaces;
using Taskify.Application.Services;
using Taskify.Application.Validator.Item;

namespace Taskify.Application
{
    public  static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IItemService,ItemService>();
            services.AddScoped<IValidator<CreateItem>, CreateItemValidator>();
            return services;
        }
    }
}
