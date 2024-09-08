using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.Common;
using Taskify.Application.DTOs.SubItem;
using Taskify.Application.Interfaces;
using Taskify.Domain.Entities;
using Taskify.Domain.SeedWorks;
using Taskify.Application.Exceptions;
using Taskify.Application.Constant;
namespace Taskify.Application.Services
{
    public class SubItemService : ISubItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<SubItem> _subItemValidator;
        public SubItemService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<SubItem> subItemValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _subItemValidator = subItemValidator;
        }

        public async Task<ApiResponse<SubItemResponse>> CreateAsync(CreateSubItem request, int itemId)
        {
            var subItem = _mapper.Map<SubItem>(request);
            subItem.ItemId = itemId;
            var validateResult = await _subItemValidator.ValidateAsync(subItem);
            if (!validateResult.IsValid)
            {
                throw new BadRequestException(ResponseMessage.CreateFailure, validateResult);
            }
            var createdItem = await _unitOfWork.SubItems.AddAsync(subItem);
            await _unitOfWork.SaveAsync();
            var mappedResponse = _mapper.Map<SubItemResponse>(createdItem);
            var repsonse = ApiResponse<SubItemResponse>.Created(ResponseMessage.Success, mappedResponse);
            return repsonse;



        }

        public Task<ApiResponse<SubItemResponse>> CreateAsync(CreateSubItem request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<SubItemResponse>>> GetListAsync(bool isArchived)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SubItemResponse>> UpdateAsync(UpdateSubItem request)
        {
            throw new NotImplementedException();
        }
    }
}
