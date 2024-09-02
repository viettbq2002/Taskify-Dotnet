using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.Common
{
    public  class PagedList<T>
    {
        public int CurrentPage { get; init; } = 1;
        public int PageSize { get; init; } = 25;
        public long Totals { get; init; } = 0;
        public IEnumerable<T> Results { get; init; } = [];
    }
}
