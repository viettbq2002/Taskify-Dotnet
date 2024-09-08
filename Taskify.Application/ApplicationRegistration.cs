using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Taskify.Application.DTOs.Item;
using Taskify.Application.Interfaces;
using Taskify.Application.Services;
using Taskify.Application.Validator.Item;
using Taskify.Domain.Entities;
using Taskify.Application.Validator.SubItem;

namespace Taskify.Application
{
    public  static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IItemService,ItemService>();
            services.AddScoped<ISubItemService,SubItemService>();
            services.AddScoped<IValidator<CreateItem>, CreateItemValidator>();
            services.AddScoped<IValidator<SubItem>, CreateSubItemValidator>();
            return services;
        }
    }
}
