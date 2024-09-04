﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.Interfaces;

namespace Taskify.Domain.SeedWorks
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository Category { get; }
        IItemRepository Item{ get; }
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
