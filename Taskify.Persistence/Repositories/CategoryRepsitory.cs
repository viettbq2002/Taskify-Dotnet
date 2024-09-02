using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Entities;
using Taskify.Domain.Interfaces;
using Taskify.Domain.SeedWorks;
using Taskify.Persistence.Context;

namespace Taskify.Persistence.Repositories
{
    public class CategoryRepsitory : GenericRepository<ItemCateogry>, ICategoryRepository
    {
        protected CategoryRepsitory(TaskifyDbContext context) : base(context)
        {
        }
    }
}
