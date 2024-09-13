using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Domain.Specifications.Item
{
    public class CompletedTask : BaseSpecification<Entities.Item>
    {
        public CompletedTask(bool isCompleted) : base(x => x.IsCompleted == isCompleted)
        {
        }
    }
}
