using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Entities;

namespace Taskify.Persistence.Context.Configures
{
    public class ItemConfiguruation : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Navigation(p => p.SubItems).AutoInclude();
        }
    }
}
