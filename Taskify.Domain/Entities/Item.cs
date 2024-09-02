using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.SeedWorks;

namespace Taskify.Domain.Entities
{
    public class Item : BaseEntity
    {
      
        public int CategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string? Note { get; set; }
        public bool IsTodayItem = false;
        public bool IsCompleted { get; set; } = false;
        public bool IsArchived { get; set; } = false ;
        public DateTime? DueDate { get; set; }
        public ICollection<SubItem> SubItems { get; set; } = [];
        public ItemCateogry? Category { get; set; }
        public ICollection<Tag> Tags { get; set; } = [];

    }
}
