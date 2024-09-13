using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Domain.Specifications.Item
{
    public class ArchivedTask : BaseSpecification<Entities.Item>
    {
        public ArchivedTask(bool isArchived) : base(x => x.IsArchived == isArchived)
        {
        }
    }
}
