﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;
using Taskify.Application.Constant;
using Taskify.Application.DTOs.ItemCategory;
using Taskify.Application.Exceptions;
using Taskify.Application.Interfaces;
using Taskify.Domain.Entities;
using Taskify.Domain.SeedWorks;
using Taskify.Domain.Specifications;

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
            var createdCategory = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            var mappedResponse = _mapper.Map<ItemCategoryResponse>(createdCategory);
            var response = ApiResponse<ItemCategoryResponse>.Created(ResponseMessage.Created, mappedResponse);
            return response;


        }


        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<ItemCategoryDetail>> GetAsync(int id)
        {
            var specification = new GetCategoryWithItems(id);
            var category = _unitOfWork.Categories.SelectOne(specification).ProjectTo<ItemCategoryDetail>(_mapper.ConfigurationProvider);
            var mappedResponse = await category.FirstOrDefaultAsync() ?? throw new NotFoundException(ResponseMessage.NotFound); 
            var response = ApiResponse<ItemCategoryDetail>.Success(ResponseMessage.Success, mappedResponse);
            return response;
        }

        public async Task<ApiResponse<IEnumerable<ItemCategoryResponse>>> GetListAsync(bool isArchived)
        {
            var categories = _unitOfWork.Categories.GetAll(x => x.IsArchived == isArchived);
            var mappedCateogries = await categories.ProjectTo<ItemCategoryResponse>(_mapper.ConfigurationProvider).ToListAsync();
            var response = ApiResponse<ItemCategoryResponse>.GetListSuccess(ResponseMessage.Success, mappedCateogries);
            return response;

        }

        public Task<ApiResponse<ItemCategoryResponse>> UpdateAsync(int key, UpdateItemCategory request)
        {
            throw new NotImplementedException();
        }
    }
}
