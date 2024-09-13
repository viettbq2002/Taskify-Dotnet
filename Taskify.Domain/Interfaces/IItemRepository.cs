using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Entities;
using Taskify.Domain.SeedWorks;

namespace Taskify.Domain.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task DeleteManyAsync(ISpecification<Item> specification);

    }
}
