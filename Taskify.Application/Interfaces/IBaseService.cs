using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Application.Interfaces
{
    public interface IBaseService<T, TResponseDto,TCreateDto,TUpdateDto,TKey> where T : class
    {
        Task<TResponseDto> CreateAsync(TCreateDto request);
        Task<TResponseDto> UpdateAsync(TUpdateDto request);
        Task<TResponseDto> DeleteAsync(TKey key);



    }
}
