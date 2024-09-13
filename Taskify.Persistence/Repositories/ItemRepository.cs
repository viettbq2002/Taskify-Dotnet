using Microsoft.EntityFrameworkCore;
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
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(TaskifyDbContext context) : base(context)
        {
        }

        public async Task DeleteManyAsync(ISpecification<Item> specification)
        {
            await _context.Items.Where(specification.Predicate).ExecuteDeleteAsync();
        }
    }
}
