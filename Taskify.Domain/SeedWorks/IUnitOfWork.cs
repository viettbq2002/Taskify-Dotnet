using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Domain.SeedWorks
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
