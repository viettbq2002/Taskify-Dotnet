using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.Item;

namespace Taskify.Application.DTOs.ItemCategory
{
    public class ItemCategoryDetail : ItemCategoryResponse
    {
        public IEnumerable<ItemResponse> Items { get; set; } = [];
    }
}
