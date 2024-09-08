using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Entities;
using Taskify.Domain.Interfaces;
using Taskify.Persistence.Context;

namespace Taskify.Persistence.Repositories
{
    public class SubItemRepository : GenericRepository<SubItem>, ISubItemRepository
    {
        public SubItemRepository(TaskifyDbContext context) : base(context)
        {
        }
    }
}
