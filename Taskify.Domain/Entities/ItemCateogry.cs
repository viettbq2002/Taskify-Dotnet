using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.SeedWorks;

namespace Taskify.Domain.Entities
{
    public class ItemCateogry : BaseEntity
    {
        public string CategoryName { get; set; } = null!;
        public bool isArchived { get; set; } = false;
        public ICollection<Item> Items { get; set; } = [];
    }
}
