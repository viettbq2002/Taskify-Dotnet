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
        public ICategoryRepository Categories  { get; }
        public IItemRepository Items { get; }

        #endregion
        #region Constructor
        public UnitOfWork(TaskifyDbContext context, ICategoryRepository categoryRepository, IItemRepository items)
        {
            _context = context;
            Categories = categoryRepository;
            Items = items;
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
        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
