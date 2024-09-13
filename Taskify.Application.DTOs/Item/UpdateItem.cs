using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.DTOs.Item
{
    public class UpdateItem: CreateItem
    {
        public string? Note {  get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsArchived { get; set; }
    }
}
