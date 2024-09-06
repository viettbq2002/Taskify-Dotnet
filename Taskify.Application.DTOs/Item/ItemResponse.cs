using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.Common;
using Taskify.Application.DTOs.SubItem;

namespace Taskify.Application.DTOs.Item
{
    public class ItemResponse : BaseResponseDto
    {
        public string Title { get; set; } = null!;
        public string? Note { get; set; }
        public bool IsTodayItem = false;
        public bool IsCompleted { get; set; } = false;
        public bool IsArchived { get; set; } = false;
        public DateTime? DueDate { get; set; }
        public ICollection<SubItemResponse> SubItems { get; set; } = [];

    }
}
