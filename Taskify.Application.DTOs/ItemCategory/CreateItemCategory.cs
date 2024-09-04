using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.DTOs.ItemCategory
{
    public class CreateItemCategory
    {
        [Required]
        [MinLength(3, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "The {0} must be a maximum of {1} characters long.")]
        public string CategoryName { get; set; } = null!;
    }
}
