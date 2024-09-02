using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.SeedWorks;

namespace Taskify.Domain.Entities
{
    public class Tag : BaseEntity
    {
        
        public string TagName { get; set; } = null!;
        public bool IsArchived { get; set; } = false;
        public virtual ICollection<Item> Items { get; set; } = [];
    }
}
