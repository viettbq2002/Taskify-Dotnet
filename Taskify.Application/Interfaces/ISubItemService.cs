using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;
using Taskify.Application.DTOs.SubItem;
using Taskify.Domain.Entities;

namespace Taskify.Application.Interfaces
{
    public interface ISubItemService: IBaseService<SubItem, SubItemResponse, CreateSubItem, UpdateSubItem, int>
    {
        Task<ApiResponse<SubItemResponse>> CreateAsync(CreateSubItem request,int itemId);

    }
}
