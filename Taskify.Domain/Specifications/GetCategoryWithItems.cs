using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Entities;

namespace Taskify.Domain.Specifications
{
    public class GetCategoryWithItems : BaseSpecification<ItemCateogry>
    {
        public GetCategoryWithItems(int categoryId) : base(c => c.Id == categoryId)
        {
            AddInclude(c => c.Items);
            AddNestedInclude("Items.SubItems");
            
        }
    }
}
