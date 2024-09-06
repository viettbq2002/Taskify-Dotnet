using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Interfaces;
using Taskify.Domain.SeedWorks;
using Taskify.Persistence.Context;
using Taskify.Persistence.Repositories;

namespace Taskify.Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services , IConfiguration configuration) {

            services.AddDbContext<TaskifyDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepsitory>();
            services.AddScoped<IItemRepository, ItemRepository>();
            return services;
        }
    }
}
