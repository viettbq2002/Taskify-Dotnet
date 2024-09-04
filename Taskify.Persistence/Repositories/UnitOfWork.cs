using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Interfaces;
using Taskify.Domain.SeedWorks;
using Taskify.Persistence.Context;

namespace Taskify.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attribute
        private readonly TaskifyDbContext _context;
        public ICategoryRepository Category { get; }
        public IItemRepository Item { get; }

        #endregion
        #region Constructor
        public UnitOfWork(TaskifyDbContext context, ICategoryRepository category, IItemRepository item)
        {
            _context = context;
            Category = category;
            Item = item;
        }
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
