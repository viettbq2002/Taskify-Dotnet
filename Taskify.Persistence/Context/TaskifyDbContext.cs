using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Entities;
using Taskify.Domain.SeedWorks;

namespace Taskify.Persistence.Context
{
    public class TaskifyDbContext(DbContextOptions options) : DbContext(options)
    {
        #region Entities
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemCateogry> ItemCateogries{ get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<SubItem> SubItems { get; set; } = null!;
        #endregion

        public EntityEntry SoftRemove(object entity)
        {
            var isArchivedProperty = entity.GetType().GetProperty("IsArchived") ?? throw new Exception("Item Not Allow To Remove");
            var isArchivedValue = isArchivedProperty.GetValue(entity);

            if (isArchivedValue == null || isArchivedValue is not bool isArchived)
            {
                throw new Exception("Item Not Allow To Remove");
            }

            if (isArchived)
            {
                throw new Exception("Item Not Allow To Remove");
            }

            isArchivedProperty.SetValue(entity, true);

            var entry = Entry(entity);
            entry.State = EntityState.Modified;

            return entry;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Modified || e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

      
    }

}
