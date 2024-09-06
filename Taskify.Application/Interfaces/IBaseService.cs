using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;

namespace Taskify.Application.Interfaces
{
    public interface IBaseService<T, TResponseDto,TCreateDto,TUpdateDto,TKey> where T : class
    {
        Task<ApiResponse<TResponseDto>> CreateAsync(TCreateDto request);
        Task<ApiResponse<TResponseDto>> UpdateAsync(TUpdateDto request);
        Task DeleteAsync(TKey key);
        Task<ApiResponse<IEnumerable<TResponseDto>>> GetListAsync();

    }
}
