using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.Common;

namespace Taskify.Application.DTOs.ItemCategory
{
    public class ItemCategoryResponse: BaseResponseDto
    {
        public bool IsArchived { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
