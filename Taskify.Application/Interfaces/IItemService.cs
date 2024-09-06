using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;
using Taskify.Application.DTOs.Item;
using Taskify.Domain.Entities;

namespace Taskify.Application.Interfaces
{
    public interface IItemService : IBaseService<Item,ItemResponse,CreateItem,UpdateItem,int>
    {
    }
}
