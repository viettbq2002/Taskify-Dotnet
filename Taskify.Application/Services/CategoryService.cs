using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;
using Taskify.Application.DTOs.ItemCategory;
using Taskify.Application.Interfaces;
using Taskify.Domain.Entities;
using Taskify.Domain.SeedWorks;

namespace Taskify.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ItemCategoryResponse>> CreateAsync(CreateItemCategory request)
        {
            var category = _mapper.Map<ItemCateogry>(request);
            var createdCategory = await _unitOfWork.Category.AddAsync(category);
            var mappedResponse = _mapper.Map<ItemCategoryResponse>(createdCategory);
            var response = ApiResponse<ItemCategoryResponse>.Created("Category created success", mappedResponse);
            return response;


        }

        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemCategoryResponse>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ItemCategoryResponse>> UpdateAsync(UpdateItemCategory request)
        {
            throw new NotImplementedException();
        }
    }
}
