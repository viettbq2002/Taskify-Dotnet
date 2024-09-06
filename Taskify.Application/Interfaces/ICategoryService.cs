using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;
using Taskify.Application.DTOs.ItemCategory;
using Taskify.Domain.Entities;

namespace Taskify.Application.Interfaces
{
    public interface ICategoryService : IBaseService<ItemCateogry,ItemCategoryResponse,CreateItemCategory,UpdateItemCategory,int>
    {
        public Task<ApiResponse<ItemCategoryDetail>> GetAsync(int id);


     
    }
}
