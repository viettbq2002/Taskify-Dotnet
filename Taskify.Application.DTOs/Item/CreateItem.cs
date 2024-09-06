using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.DTOs.Item
{
    public class CreateItem
    {
        [Required]
        public string Title { get; set; } = null!;
        public int? CategoryId { get; set; }

    }
}
