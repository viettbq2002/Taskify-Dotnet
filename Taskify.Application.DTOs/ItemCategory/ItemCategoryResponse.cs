using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.DTOs.ItemCategory
{
    public class ItemCategoryResponse
    {
        public int Id { get; set; }
        public bool IsArchived { get; set; }
        public string CategoryName { get; set; } = null!;



    }
}
