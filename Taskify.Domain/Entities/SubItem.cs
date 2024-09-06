using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.SeedWorks;

namespace Taskify.Domain.Entities
{
    public class SubItem : BaseEntity
    {
        public string Title { get; set; } = null!; 
        public bool IsCompleted { get; set; } = false;
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!; 
    }
}
