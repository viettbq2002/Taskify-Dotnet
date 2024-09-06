using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.Common;

namespace Taskify.Application.DTOs.SubItem
{
    public class SubItemResponse : BaseResponseDto
    {
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;
    }
}
